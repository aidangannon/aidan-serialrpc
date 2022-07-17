using NSubstitute;
using NUnit.Framework;

namespace Aidan.SerialRPC.Tests.Marshalling.WrappedArgMarshalling.WrappedIntArgMarshallerTests;

public class When_Marshalled : Given_A_WrappedIntArgMarshaller
{
    [ Test ]
    public void Then_Marshaller_Was_Called_Once( )
    {
        SUT.Marshal( 0 );
        MockIntArgMarshaller
            .Received( 1 )
            .Marshal( Arg.Any<int>( ) );
    }
}