using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling;

namespace Aidan.SerialRPC.Marshalling.RawArgMarshalling;

public class BoolArgParser : IBoolArgParser
{
    public byte [ ] Parse( bool dataIn )
    {
        return dataIn switch
        {
            true => new byte [ ] { 1 },
            false => new byte [ ] { 0 }
        };
    }
}