using NSubstitute;
using NUnit.Framework;

namespace Aidan.SerialRPC.Tests.Marshalling.WrappedArgMarshalling.WrappedStringArgMarshallerTests;

public class When_Marshalled : Given_A_WrappedStringArgMarshaller
{
    [ Test ]
    public void Then_Marshaller_Was_Called_Once( )
    {
        SUT.Marshal( "HELLO WORLD" );
        MockStringArgMarshaller
            .Received( 1 )
            .Marshal( Arg.Any<string>( ) );
    }
}