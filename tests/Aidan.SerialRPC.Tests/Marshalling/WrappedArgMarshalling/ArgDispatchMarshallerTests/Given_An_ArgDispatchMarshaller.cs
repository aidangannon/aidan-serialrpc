using Aidan.Common.Utils.Test;
using Aidan.SerialRPC.Core.Interfaces.Contract;
using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling;
using Aidan.SerialRPC.Marshalling.WrappedArgMarshalling;
using NSubstitute;

namespace Aidan.SerialRPC.Tests.Marshalling.WrappedArgMarshalling.ArgDispatchMarshallerTests;

public class Given_An_ArgDispatchMarshaller : GivenWhenThen<IArgDispatchMarshaller>
{
    protected IFuncMarshallerFactory MockFuncMarshallerFactory;

    protected override void Given( )
    {
        MockFuncMarshallerFactory = Substitute.For<IFuncMarshallerFactory>( );
        SUT = new ArgDispatchMarshaller( MockFuncMarshallerFactory );
    }
}