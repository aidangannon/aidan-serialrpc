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
        var interfaceType = typeof( T );
        if( !interfaceType.IsInterface )
        {
            throw new DynamicProxyException( "dynamic proxy must be generated from an interface" );
        }
        
        var typeName = CreateDynamicTypeName(interfaceType);

        var interfaces = new [ ] { interfaceType };

        return moduleBuilder.DefineType( typeName, TypeAttributes.Public | TypeAttributes.Class, null, interfaces );
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

    private static bool ImplementMethods<T>( TypeBuilder typeBuilder )
    {
        var interfaceType = typeof( T );
        var methods = interfaceType.GetMethods( );

        foreach( var method in methods )
        {
            var methodBuilder = BuildDynamicMethod( typeBuilder, method );
            ProxyMethod( methodBuilder );
            typeBuilder.DefineMethodOverride( methodBuilder, method );
        }
        
        return true;
    }

    private static void ProxyMethod( MethodBuilder methodBuilder )
    {
        var ilGenerator = methodBuilder.GetILGenerator( );

        var consoleWrite = typeof( Console ).GetMethod( "WriteLine", new [ ] { typeof( string ) } )!;
        
        ilGenerator.Emit( OpCodes.Ldstr, "im dynamic as fuck boi" );
        ilGenerator.Emit( OpCodes.Call, consoleWrite );
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
        var assemblyBuilder = BuildDynamicAssembly( );
        var moduleBuilder = BuildDynamicModule( assemblyBuilder );
        var typeBuilder = BuildDynamicType<T>( moduleBuilder );
        if( !ImplementMethods<T>( typeBuilder ) )
        {
            throw new DynamicProxyException( "cant proxy methods" );
        }

        return Activator.CreateInstance(typeBuilder.CreateType( )!) as T;
    }
}