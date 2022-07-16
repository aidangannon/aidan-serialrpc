using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.RawMarshalling;

namespace Aidan.SerialRPC.Marshalling.RawArgMarshalling;

public class ByteArgMarshaller : IByteArgMarshaller
{
    public byte [ ] Parse( byte dataIn ) { return new [ ] { dataIn }; }
}