using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.RawMarshalling;
using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.WrappedMarshalling;

namespace Aidan.SerialRPC.Marshalling.RawArgMarshalling;

public class IntArgMarshaller : IIntArgMarshaller
{
    private readonly IPaddingInterleaveMarshaller _paddingInterleaveMarshaller;

    public IntArgMarshaller( IPaddingInterleaveMarshaller paddingInterleaveMarshaller )
    {
        _paddingInterleaveMarshaller = paddingInterleaveMarshaller;
    }

    public byte [ ] Parse( int dataIn )
    {
        var bytes = BitConverter.GetBytes( dataIn );
        Array.Resize( ref bytes, Array.FindLastIndex( bytes, b => b != 0 ) + 1 );
        return _paddingInterleaveMarshaller.Parse( bytes );
    }
}