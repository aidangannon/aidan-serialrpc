using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling;

namespace Aidan.SerialRPC.Marshalling.RawArgMarshalling;

public class IntArgParser : IIntArgParser
{
    private readonly IPaddingInterleaveParser _paddingInterleaveParser;

    public IntArgParser( IPaddingInterleaveParser paddingInterleaveParser )
    {
        _paddingInterleaveParser = paddingInterleaveParser;
    }

    public byte [ ] Parse( int dataIn )
    {
        var bytes = BitConverter.GetBytes( dataIn );
        Array.Resize( ref bytes, Array.FindLastIndex( bytes, b => b != 0 ) + 1 );
        return _paddingInterleaveParser.Parse( bytes );
    }
}