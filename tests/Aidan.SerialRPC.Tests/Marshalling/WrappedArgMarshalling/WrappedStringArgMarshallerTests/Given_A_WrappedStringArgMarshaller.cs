using Aidan.Common.Utils.Test;
using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.RawMarshalling;
using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.WrappedMarshalling;
using Aidan.SerialRPC.Core.Interfaces.Excluded;
using Aidan.SerialRPC.Marshalling.WrappedArgMarshalling;
using NSubstitute;

namespace Aidan.SerialRPC.Tests.Marshalling.WrappedArgMarshalling.WrappedStringArgMarshallerTests;

public class Given_A_WrappedStringArgMarshaller : GivenWhenThen<IGenericWrappedArgMarshaller<string>>
{
    protected IStringArgMarshaller MockStringArgMarshaller;
    protected IWrappedArgMarshaller MockWrappedArgMarshaller;

    protected override void Given( )
    {
        MockStringArgMarshaller = Substitute.For<IStringArgMarshaller>( );
        MockWrappedArgMarshaller = Substitute.For<IWrappedArgMarshaller>( );
        SUT = new WrappedStringArgMarshaller( MockStringArgMarshaller, MockWrappedArgMarshaller );
    }
}