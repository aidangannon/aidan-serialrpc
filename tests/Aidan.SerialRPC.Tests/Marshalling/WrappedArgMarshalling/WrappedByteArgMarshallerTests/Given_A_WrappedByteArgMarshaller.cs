using Aidan.Common.Utils.Test;
using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.RawMarshalling;
using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.WrappedMarshalling;
using Aidan.SerialRPC.Core.Interfaces.Excluded;
using Aidan.SerialRPC.Marshalling.WrappedArgMarshalling;
using NSubstitute;

namespace Aidan.SerialRPC.Tests.Marshalling.WrappedArgMarshalling.WrappedByteArgMarshallerTests;

public class Given_A_WrappedByteArgMarshaller : GivenWhenThen<IGenericWrappedArgMarshaller<byte>>
{
    private IWrappedArgMarshaller _mockWrappedArgMarshaller;
    protected IByteArgMarshaller MockByteArgMarshaller;

    protected override void Given( )
    {
        _mockWrappedArgMarshaller = Substitute.For<IWrappedArgMarshaller>( );
        MockByteArgMarshaller = Substitute.For<IByteArgMarshaller>( );
        SUT = new WrappedByteArgMarshaller( MockByteArgMarshaller, _mockWrappedArgMarshaller );
    }
}