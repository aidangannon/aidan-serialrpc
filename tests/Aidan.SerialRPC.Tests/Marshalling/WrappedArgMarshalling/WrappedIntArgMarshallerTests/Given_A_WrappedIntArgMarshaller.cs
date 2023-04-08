using Aidan.Common.Utils.Test;
using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.RawMarshalling;
using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.WrappedMarshalling;
using Aidan.SerialRPC.Core.Interfaces.Excluded;
using Aidan.SerialRPC.Marshalling.WrappedArgMarshalling;
using NSubstitute;

namespace Aidan.SerialRPC.Tests.Marshalling.WrappedArgMarshalling.WrappedIntArgMarshallerTests;

public class Given_A_WrappedIntArgMarshaller : GivenWhenThen<IGenericWrappedArgMarshaller<int>>
{
    protected IIntArgMarshaller MockIntArgMarshaller;
    protected IWrappedArgMarshaller MockWrappedArgMarshaller;

    protected override void Given( )
    {
        MockIntArgMarshaller = Substitute.For<IIntArgMarshaller>( );
        MockWrappedArgMarshaller = Substitute.For<IWrappedArgMarshaller>( );
        SUT = new WrappedIntArgMarshaller( MockIntArgMarshaller, MockWrappedArgMarshaller );
    }
}