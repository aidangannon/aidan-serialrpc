using System.Reflection;
using System.Reflection.Emit;
using Aidan.SerialRPC.Core.Exceptions;

namespace Aidan.SerialRPC.DynamicProxies;

public static class DynamicTypeGenerator
{
    private static AssemblyBuilder BuildDynamicAssembly( ) =>
        AssemblyBuilder.DefineDynamicAssembly( new AssemblyName( CreateRandomAssemblyName( ) ),
            AssemblyBuilderAccess.Run );

    private static ModuleBuilder BuildDynamicModule( AssemblyBuilder assemblyBuilder ) =>
        assemblyBuilder.DefineDynamicModule( CreateRandomAssemblyName( ) );

    private static string CreateRandomAssemblyName( ) =>
        $"Aidan.SerialRPC.{CreateRandomName( )}";

    private static string CreateRandomName( ) =>
        Guid.NewGuid( ).ToString( ).Replace( "-", "" );

    private static TypeBuilder BuildDynamicType<T>( ModuleBuilder moduleBuilder )
    {
        var baseType = typeof( BaseProxy );
        var interfaceType = typeof( T );
        if( !interfaceType.IsInterface )
        {
            throw new DynamicProxyException( "dynamic proxy must be generated from an interface" );
        }
        
        var typeName = CreateDynamicTypeName(interfaceType);

        var interfaces = new [ ] { interfaceType };

        return moduleBuilder.DefineType( typeName, TypeAttributes.Public | TypeAttributes.Class, baseType, interfaces );
    }

    private static string CreateDynamicTypeName( Type interfaceType )
    {
        var interfaceName = TrimInterfaceStandardCharecters( interfaceType.Name );
        return $"Dynamic{CreateRandomName( )}{interfaceName}";
    }

    private static string TrimInterfaceStandardCharecters( string interfaceName )
    {
        var ifInterfaceNameDoesNotMatchCSharpStandard = !(interfaceName.StartsWith( "I" ) && char.IsUpper( interfaceName[ 1 ] ));
        
        return ifInterfaceNameDoesNotMatchCSharpStandard ? interfaceName : interfaceName.Remove( 0, 1 );
    }

    private static bool ImplementMethods<T>( TypeBuilder typeBuilder, Type baseProxy )
    {
        var interfaceType = typeof( T );
        var methods = interfaceType.GetMethods( );

        foreach( var method in methods )
        {
            var methodBuilder = BuildDynamicMethod( typeBuilder, method );
            ProxyMethod( methodBuilder, method, baseProxy );
            typeBuilder.DefineMethodOverride( methodBuilder, method );
        }
        
        return true;
    }

    private static void ProxyMethod( MethodBuilder methodBuilder, MethodInfo methodToProxy, Type baseProxy )
    {
        var ilGenerator = methodBuilder.GetILGenerator( );
        var addStringArgMethod = baseProxy.GetMethod( "AddStringArg", BindingFlags.NonPublic | BindingFlags.Instance );
        var addIntArgMethod = baseProxy.GetMethod( "AddIntArg", BindingFlags.NonPublic | BindingFlags.Instance );
        var publishMethod = baseProxy.GetMethod( "PublishShit", BindingFlags.NonPublic | BindingFlags.Instance );

        var consoleWrite = typeof( Console ).GetMethod( "WriteLine", new [ ] { typeof( string ) } )!;

        var methodParams = methodToProxy.GetParameters( );
        for( var i = 0; i < methodToProxy.GetParameters( ).Length; i++ )
        {
            ilGenerator.Emit( OpCodes.Ldarg, 0 );
            ilGenerator.Emit( OpCodes.Ldarg, i+1 );
            var parameterType = methodParams[ i ].ParameterType;
            if( parameterType == typeof( string ) )
            {
                ilGenerator.Emit( OpCodes.Call, addStringArgMethod! );
            }
            if( parameterType == typeof( int ) )
            {
                ilGenerator.Emit( OpCodes.Call, addIntArgMethod! );
            }
        }

        if( methodToProxy.ReturnType == typeof( void ) )
        {
            ilGenerator.Emit( OpCodes.Ldarg, 0 );
            ilGenerator.Emit( OpCodes.Ldc_I4, 0 );
            ilGenerator.Emit( OpCodes.Call, publishMethod! );
            ilGenerator.Emit( OpCodes.Pop );
            ilGenerator.Emit( OpCodes.Ret );
        }
        else if( methodToProxy.ReturnType == typeof( int ) )
        {
            ilGenerator.Emit( OpCodes.Ldarg, 0 );
            ilGenerator.Emit( OpCodes.Ldc_I4, 1 );
            ilGenerator.Emit( OpCodes.Call, publishMethod! );
            ilGenerator.Emit( OpCodes.Ret );
        }
    }

    private static void ImplementDynamicConstructor( TypeBuilder typeBuilder, Type baseProxy )
    {
        var baseConstructor = baseProxy.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault()!;
        // TODO: replace with real marshalling dependencies
        var dynamicConstructorBuilder = typeBuilder.DefineConstructor( MethodAttributes.Public,
            CallingConventions.Standard | CallingConventions.HasThis, new [ ] { typeof( TestLogger ) } );

        var ilGenerator = dynamicConstructorBuilder.GetILGenerator( );
        
        ilGenerator.Emit( OpCodes.Ldarg, 0 );
        ilGenerator.Emit( OpCodes.Ldarg, 1 );
        ilGenerator.Emit( OpCodes.Call, baseConstructor );
        ilGenerator.Emit( OpCodes.Ret );
    }

    private static MethodBuilder BuildDynamicMethod( TypeBuilder typeBuilder, MethodInfo methodFromInterface ) =>
        typeBuilder.DefineMethod( methodFromInterface.Name,
            MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.Virtual,
            methodFromInterface.CallingConvention,
            methodFromInterface.ReturnType,
            methodFromInterface.GetParameters( ).Select( x => x.ParameterType ).ToArray( ) );

    public static T Build<T>( ) where T : class
    {
        var baseProxy = typeof( BaseProxy );
        var assemblyBuilder = BuildDynamicAssembly( );
        var moduleBuilder = BuildDynamicModule( assemblyBuilder );
        var typeBuilder = BuildDynamicType<T>( moduleBuilder );
        if( !ImplementMethods<T>( typeBuilder, baseProxy ) )
        {
            throw new DynamicProxyException( "cant proxy methods" );
        }

        ImplementDynamicConstructor( typeBuilder, baseProxy );

        return Activator.CreateInstance( typeBuilder.CreateType( )!, new TestLogger(  ) ) as T ??
               throw new DynamicProxyException( "instance could not be activated" );
    }
}