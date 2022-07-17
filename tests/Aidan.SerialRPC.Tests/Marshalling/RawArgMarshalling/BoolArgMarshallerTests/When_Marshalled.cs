using NUnit.Framework;

namespace Aidan.SerialRPC.Tests.Marshalling.RawArgMarshalling.BoolArgMarshallerTests;

public class When_Marshalled : Given_A_BoolArgMarshaller
{
    [ TestCase( false, new byte [ ] { 0 } ) ]
    [ TestCase( true, new byte [ ] { 1 } ) ]
    public void Then_Bit_Should_Be_Correctly_Marshalled_Into_Bytes( bool bitIn, byte [ ] bytesOut )
    {
        CollectionAssert.AreEqual( bytesOut, SUT.Marshal( bitIn ) );
    }
}