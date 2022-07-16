using System.Text;
using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling;

namespace Aidan.SerialRPC.Marshalling.RawArgMarshalling;

public class UTF8StringArgParser : IStringArgParser
{
    private readonly IPaddingInterleaveParser _paddingInterleaveParser;

    public UTF8StringArgParser( IPaddingInterleaveParser paddingInterleaveParser )
    {
        _paddingInterleaveParser = paddingInterleaveParser;
    }
    
    public byte [ ] Parse( string dataIn )
    {
        var bytes = Encoding.UTF8.GetBytes( dataIn );
        return _paddingInterleaveParser.Parse( bytes );
    }
}