using NUnit.Framework;

namespace Aidan.SerialRPC.Tests.Marshalling.WrappedArgMarshalling.PaddingInterleaveMarshallerTests;

public class When_Marshalled : Given_A_F0PaddingInterleaveMarshaller
{
    [ TestCase( new byte [ ] { 0x04, 0x07, 0x08 }, new byte [ ] { 0x04, 0xF0, 0x07, 0xF0, 0x08 } ) ]
    [ TestCase( new byte [ ] { 0x04, 0x08 }, new byte [ ] { 0x04, 0xF0, 0x08 } ) ]
    [ TestCase( new byte [ ] { 0x04 }, new byte [ ] { 0x04 } ) ]
    [ TestCase( new byte [ ] { }, new byte [ ] { } ) ]
    public void Then_Bytes_Are_Interleaved_With_F0_Padding( byte [ ] bytesIn, byte [ ] bytesOut )
    {
        CollectionAssert.AreEqual( bytesOut, SUT.Marshal( bytesIn ) );
    }
}