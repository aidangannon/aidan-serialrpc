using Aidan.Common.Utils.Test;
using Aidan.SerialRPC.Core.Interfaces.Contract;
using Aidan.SerialRPC.Ninject;
using Ninject;

namespace Aidan.SerialRPC.Tests.Ninject;

public abstract class Given_A_FuncMarshallerFactory : GivenWhenThen<IFuncMarshallerFactory>
{
    protected IKernel Kernel;

    protected override void Given( )
    {
        var module = new SerialRPCModule( );
        Kernel = new StandardKernel( );
        module.OnLoad( Kernel );
        SUT = Kernel.Get<IFuncMarshallerFactory>( );
    }
}