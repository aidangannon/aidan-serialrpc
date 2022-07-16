using System.Text;
using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.RawMarshalling;
using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.WrappedMarshalling;

namespace Aidan.SerialRPC.Marshalling.RawArgMarshalling;

public class Utf8StringArgMarshaller : IStringArgMarshaller
{
    private readonly IPaddingInterleaveMarshaller _paddingInterleaveMarshaller;

    public Utf8StringArgMarshaller( IPaddingInterleaveMarshaller paddingInterleaveMarshaller )
    {
        _paddingInterleaveMarshaller = paddingInterleaveMarshaller;
    }
    
    public byte [ ] Parse( string dataIn )
    {
        var bytes = Encoding.UTF8.GetBytes( dataIn );
        return _paddingInterleaveMarshaller.Parse( bytes );
    }
}