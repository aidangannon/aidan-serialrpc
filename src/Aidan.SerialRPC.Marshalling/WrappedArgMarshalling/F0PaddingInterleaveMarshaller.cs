using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.WrappedMarshalling;

namespace Aidan.SerialRPC.Marshalling.WrappedArgMarshalling;

public class F0PaddingInterleaveMarshaller : IPaddingInterleaveMarshaller
{
    public byte [ ] Marshal( byte [ ] dataIn )
    {
        if( dataIn.Length == 0 )
        {
            return Array.Empty<byte>( );
        }
        var newPaddedCollection = new List<byte>( );
        for( var i = 0; i < dataIn.Length - 1; i++ )
        {
            newPaddedCollection.AddRange( new byte[ ] { dataIn[ i ], 0xF0 } );
        }

        newPaddedCollection.Add( dataIn.Last( ) );

        return newPaddedCollection.ToArray( );
    }
}