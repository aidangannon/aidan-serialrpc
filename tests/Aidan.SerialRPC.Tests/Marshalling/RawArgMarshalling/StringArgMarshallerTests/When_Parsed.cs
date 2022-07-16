using NSubstitute;
using NUnit.Framework;

namespace Aidan.SerialRPC.Tests.Marshalling.RawArgMarshalling.StringArgMarshallerTests;

public class When_Parsed : Given_A_UTF8StringArgMarshaller
{
    private byte[] _interleavedBytes;
    private byte[] _result;
    private byte[] _rawBytes;

    protected override void When( )
    {
        _rawBytes = new byte [ ] { 0x68, 0x65, 0x6c, 0x6c, 0x6f, 0x20, 0x77, 0x6f, 0x72, 0x6c, 0x64 };
        _interleavedBytes = new byte [ ] { 0x68, 0xF0, 0x65, 0xF0, 0x6c, 0xF0, 0x6c, 0xF0, 0x6f, 0xF0, 0x20, 0xF0, 0x77, 0xF0, 0x6f, 0xF0, 0x72, 0xF0, 0x6c, 0xF0, 0x64 };
        MockPaddingInterleaveMarshaller
            .Parse( Arg.Any<byte [ ]>( ) )
            .Returns( _interleavedBytes );
        _result = SUT.Parse( "hello world" );
    }

    [ Test ]
    public void Then_Interleaver_Was_Passed_Correct_UTF8_Bytes( )
    {
        MockPaddingInterleaveMarshaller
            .Received( )
            .Parse( Arg.Is<byte [ ]>( b => b.SequenceEqual( _rawBytes ) ) );
        MockPaddingInterleaveMarshaller
            .Received( 1 )
            .Parse( Arg.Any<byte [ ]>( ) );
    }

    [ Test ]
    public void Then_Interleaved_Bytes_Are_Returned( )
    {
        Assert.AreEqual( _interleavedBytes, _result );
    }
}