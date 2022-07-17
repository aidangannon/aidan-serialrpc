using Aidan.SerialRPC.Core.Interfaces.Excluded;

namespace Aidan.SerialRPC.Marshalling.WrappedArgMarshalling;

public class WrappedArgMarshaller : IWrappedArgMarshaller
{
    public byte [ ] Marshal( Func<byte [ ]> dataIn )
    {
        var bytes = dataIn.Invoke( );
        var bytesWithStartAndEnd = new List<byte>( );
        bytesWithStartAndEnd.Add( 0xFF );
        bytesWithStartAndEnd.AddRange( bytes );
        bytesWithStartAndEnd.Add( 0x00 );
        return bytesWithStartAndEnd.ToArray( );
    }
}