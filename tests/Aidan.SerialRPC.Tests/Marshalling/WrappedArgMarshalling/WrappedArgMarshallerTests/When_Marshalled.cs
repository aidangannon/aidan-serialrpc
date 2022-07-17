using NUnit.Framework;

namespace Aidan.SerialRPC.Tests.Marshalling.WrappedArgMarshalling.WrappedArgMarshallerTests;

public class When_Marshalled : Given_A_WrappedArgMarshaller
{
    private byte[] _result;

    protected override void When( )
    {
        _result = SUT.Marshal( new byte [ ] { 0x05, 0xF0, 0x80 } );
    }

    [ Test ]
    public void Then_Marshalled_Bytes_Are_Wrapped_With_Start_And_End_Bytes( )
    {
        CollectionAssert.AreEqual( new byte [ ] { 0xFF, 0x05, 0xF0, 0x80, 0x00 }, _result );
    }
}