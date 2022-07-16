using NSubstitute;
using NUnit.Framework;

namespace Aidan.SerialRPC.Tests.Marshalling.RawArgMarshalling.IntArgParserTests;

public class When_Parsed : Given_An_IntArgParser
{
    private int _deanaryIn;
    private byte[] _bytes;
    private byte[] _paddedBytes;
    private byte[] _result;

    protected override void When( )
    {
        _deanaryIn = 5000000;
        _bytes = new byte [ ] { 64, 75, 76 };
        _paddedBytes = new byte [ ] { 64, 240, 75, 240, 76 };
        MockPaddingInterleaveParser
            .Parse( Arg.Any<byte [ ]>( ) )
            .Returns( _paddedBytes );
        _result = SUT.Parse( _deanaryIn );
    }

    [ Test ]
    public void Then_Correct_Bytes_Are_Passed_To_The_Interleaver( )
    {
        MockPaddingInterleaveParser
            .Received( 1 )
            .Parse( Arg.Any<byte [ ]>( ) );
        MockPaddingInterleaveParser
            .Received( )
            .Parse( Arg.Is<byte [ ]>( b => b.SequenceEqual( _bytes ) ) );
    }

    [ Test ]
    public void Then_Interleaved_Bytes_Are_Returned( )
    {
        CollectionAssert.AreEqual( _paddedBytes, _result );
    }
}