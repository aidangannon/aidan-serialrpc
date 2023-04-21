using Aidan.Common.Utils.Test;
using Aidan.SerialRPC.Core.Interfaces.Excluded.Marshalling;
using NSubstitute;

namespace Aidan.SerialRPC.Tests.Marshalling.WrappedArgMarshalling.BaseArgMarshallerTests;

public abstract class Given_A_FakeWrappedArgMarshaller : GivenWhenThen<IFuncMarshaller<object>>
{
    protected IFuncMarshaller<object> MockFuncMarshaller;
    protected IWrappedArgMarshaller MockWrappedArgMarshaller;

    protected override void Given( )
    {
        MockFuncMarshaller = Substitute.For<IFuncMarshaller<object>>( );
        MockWrappedArgMarshaller = Substitute.For<IWrappedArgMarshaller>( );
        SUT = new FakeWrappedArgMarshaller( MockFuncMarshaller, MockWrappedArgMarshaller );
    }
}