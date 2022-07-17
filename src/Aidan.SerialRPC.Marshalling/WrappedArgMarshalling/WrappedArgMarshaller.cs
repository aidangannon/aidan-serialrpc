using Aidan.SerialRPC.Core.Interfaces.Excluded;

namespace Aidan.SerialRPC.Marshalling.WrappedArgMarshalling;

public class WrappedArgMarshaller : IWrappedArgMarshaller
{
    public byte [ ] Marshal( Func<byte [ ]> dataIn ) { return Array.Empty<byte>( ); }
}