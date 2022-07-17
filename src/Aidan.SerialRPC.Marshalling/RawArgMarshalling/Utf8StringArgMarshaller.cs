using System.Text;
using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.RawMarshalling;
using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.WrappedMarshalling;

namespace Aidan.SerialRPC.Marshalling.RawArgMarshalling;

public class Utf8StringArgMarshaller : IStringArgMarshaller
{
    private readonly IPaddingInterleaveMarshaller _paddingInterleaveMarshaller;
    private readonly INullConvertMarshaller _nullConvertMarshaller;

    public Utf8StringArgMarshaller( IPaddingInterleaveMarshaller paddingInterleaveMarshaller,
        INullConvertMarshaller nullConvertMarshaller )
    {
        _paddingInterleaveMarshaller = paddingInterleaveMarshaller;
        _nullConvertMarshaller = nullConvertMarshaller;
    }
    
    public byte [ ] Marshal( string dataIn )
    {
        var bytes = _nullConvertMarshaller.Marshal( ( dataIn, ( ) => Encoding.UTF8.GetBytes( dataIn ) ) );
        return _paddingInterleaveMarshaller.Marshal( bytes );
    }
}