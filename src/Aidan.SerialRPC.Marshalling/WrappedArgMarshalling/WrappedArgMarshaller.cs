using Aidan.SerialRPC.Core.Interfaces.Excluded;

namespace Aidan.SerialRPC.Marshalling.WrappedArgMarshalling;

public class WrappedArgMarshaller : IWrappedArgMarshaller
{
    public byte [ ] Marshal( byte [ ] dataIn )
    {
        var bytesWithStartAndEnd = new List<byte>( );
        bytesWithStartAndEnd.Add( 0xFF );
        bytesWithStartAndEnd.AddRange( dataIn );
        bytesWithStartAndEnd.Add( 0x00 );
        return bytesWithStartAndEnd.ToArray( );
    }
}