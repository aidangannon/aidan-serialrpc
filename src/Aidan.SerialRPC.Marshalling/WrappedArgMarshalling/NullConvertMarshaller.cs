using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.WrappedMarshalling;

namespace Aidan.SerialRPC.Marshalling.WrappedArgMarshalling;

public class NullConvertMarshaller : INullConvertMarshaller
{
    public byte [ ] Marshal( (object dataIn, Func<byte [ ]> marshaller) dataIn )
    {
        if( dataIn.dataIn == null )
        {
            return Array.Empty<byte>( );
        }

        return dataIn.marshaller.Invoke( );
    }
}