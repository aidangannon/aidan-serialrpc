using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling;

namespace Aidan.SerialRPC.Marshalling.RawArgMarshalling;

public class ByteArgParser : IByteArgParser
{
    public byte [ ] Parse( byte dataIn ) { return new [ ] { dataIn }; }
}