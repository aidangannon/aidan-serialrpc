using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.RawMarshalling;

namespace Aidan.SerialRPC.Marshalling.RawArgMarshalling;

public class BoolArgMarshaller : IBoolArgMarshaller
{
    public byte [ ] Marshal( bool dataIn )
    {
        return dataIn switch
        {
            true => new byte [ ] { 1 },
            false => new byte [ ] { 0 }
        };
    }
}