using NUnit.Framework;

namespace Aidan.SerialRPC.Tests.Marshalling.RawArgMarshalling.ByteArgMarshallerTests;

public class When_Marshalled : Given_A_ByteArgMarshaller
{
    [ Test ]
    public void Then_Byte_Input_Gets_Put_Into_An_Array( )
    {
        const byte byteIn = 0x05;
        CollectionAssert.AreEqual( new [ ] { byteIn }, SUT.Marshal( byteIn ) );
    }
}