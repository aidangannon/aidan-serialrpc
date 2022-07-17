using NSubstitute;
using NUnit.Framework;

namespace Aidan.SerialRPC.Tests.Marshalling.WrappedArgMarshalling.WrappedBoolArgMarshallerTests;

public class When_Marshalled : Given_A_WrappedBoolArgMarshaller
{
    [ Test ]
    public void Then_Marshaller_Was_Called_Once( )
    {
        SUT.Marshal( false );
        MockBoolArgMarshaller
            .Received( 1 )
            .Marshal( Arg.Any<bool>( ) );
    }
}