using NSubstitute;
using NUnit.Framework;

namespace Aidan.SerialRPC.Tests.Marshalling.WrappedArgMarshalling.WrappedByteArgMarshallerTests;

public class When_Marshalled : Given_A_WrappedByteArgMarshaller
{
    [ Test ]
    public void Then_Marshaller_Was_Called_Once( )
    {
        SUT.Marshal( 0x05 );
        MockByteArgMarshaller
            .Received( 1 )
            .Marshal( Arg.Any<byte>( ) );
    }
}