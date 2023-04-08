using Aidan.Common.Core.Interfaces.Excluded;
using Ninject.Extensions.Conventions;
using Ninject.Modules;

namespace Aidan.SerialRPC.Ninject;

public class SerialRPCModule : NinjectModule
{
    public override void Load( )
    {
        BindServices( );
        BindFactories( );
    }

    private void BindServices( )
    {
        Kernel.Bind( s => s.FromAssembliesMatching( AssemblyConstants.AidanSerialRPCAssemblies )
            .SelectAllClasses( )
            .BindDefaultInterface( ) );
    }
    
    private void BindFactories( )
    {
        Kernel.Bind( s => s.FromAssembliesMatching( AssemblyConstants.AidanSerialRPCAssemblies )
            .SelectAllInterfaces( )
            .InheritedFrom<IFactory>( )
            .BindToFactory( ) );
    }
}