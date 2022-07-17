using NSubstitute;
using NUnit.Framework;

namespace Aidan.SerialRPC.Tests.Marshalling.RawArgMarshalling.StringArgMarshallerTests;

public class When_Marshalled : Given_A_UTF8StringArgMarshaller
{
    private byte[] _interleavedBytes;
    private byte[] _result;
    private byte[] _rawBytes;
    private byte[] _rawBytesFromNullConvert;
    private Func<byte [ ]> _marshaller;

    protected override void When( )
    {
        
        _rawBytes = new byte [ ] { 0x68, 0x65, 0x6c, 0x6c, 0x6f, 0x20, 0x77, 0x6f, 0x72, 0x6c, 0x64 };
        _rawBytesFromNullConvert = Array.Empty<byte>();
        _interleavedBytes = new byte [ ] { 0x68, 0xF0, 0x65, 0xF0, 0x6c, 0xF0, 0x6c, 0xF0, 0x6f, 0xF0, 0x20, 0xF0, 0x77, 0xF0, 0x6f, 0xF0, 0x72, 0xF0, 0x6c, 0xF0, 0x64 };
        MockNullConvertMarshaller
            .Marshal( Arg.Do<(object dataIn, Func<byte [ ]> marshaller)>( p => _marshaller = p.marshaller ) );
        MockNullConvertMarshaller
            .Marshal( Arg.Any<(object dataIn, Func<byte [ ]> marshaller)>( ) )
            .Returns( _rawBytesFromNullConvert );
        MockPaddingInterleaveMarshaller
            .Marshal( Arg.Any<byte [ ]>( ) )
            .Returns( _interleavedBytes );
        _result = SUT.Marshal( "hello world" );
    }

    [ Test ]
    public void Then_Null_Convert_Was_Passed_Correct_Marshaller( )
    {
        CollectionAssert.AreEqual( _rawBytes, _marshaller( ) );
    }

    [ Test ]
    public void Then_Null_Convert_Was_Called_Once_With_Correct_Data( )
    {
        MockNullConvertMarshaller
            .Received( 1 )
            .Marshal( Arg.Any<(object dataIn, Func<byte [ ]> marshaller)>( ) );
        MockNullConvertMarshaller
            .Received( )
            .Marshal( Arg.Is<(object dataIn, Func<byte [ ]> marshaller)>( x => x.dataIn == "hello world" ) );
    }

    [ Test ]
    public void Then_Interleaver_Was_Passed_Correct_UTF8_Bytes( )
    {
        MockPaddingInterleaveMarshaller
            .Received( )
            .Marshal( Arg.Is<byte [ ]>( b => b.SequenceEqual( _rawBytesFromNullConvert ) ) );
        MockPaddingInterleaveMarshaller
            .Received( 1 )
            .Marshal( Arg.Any<byte [ ]>( ) );
    }

    [ Test ]
    public void Then_Interleaved_Bytes_Are_Returned( )
    {
        Assert.AreEqual( _interleavedBytes, _result );
    }
}