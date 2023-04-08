using Aidan.SerialRPC.Core.Exceptions;
using Aidan.SerialRPC.Core.Interfaces.Contract;
using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling;

namespace Aidan.SerialRPC.Marshalling.WrappedArgMarshalling;

public class ArgDispatchMarshaller : IArgDispatchMarshaller
{
    private readonly IFuncMarshallerFactory _funcMarshallerFactory;

    public ArgDispatchMarshaller( IFuncMarshallerFactory funcMarshallerFactory )
    {
        _funcMarshallerFactory = funcMarshallerFactory;
    }

    public byte [ ] Marshal( (Type type, object value) dataIn )
    {
        if( dataIn.type == typeof( int ) )
        {
            return _funcMarshallerFactory.Create<int>( ).Marshal( ( int )dataIn.value );
        }
        if( dataIn.type == typeof( string ) )
        {
            return _funcMarshallerFactory.Create<string>( ).Marshal( ( string )dataIn.value );
        }
        if( dataIn.type == typeof( byte ) )
        {
            return _funcMarshallerFactory.Create<byte>( ).Marshal( ( byte )dataIn.value );
        }
        if( dataIn.type == typeof( bool ) )
        {
            return _funcMarshallerFactory.Create<bool>( ).Marshal( ( bool )dataIn.value );
        }

        throw new TypeNotSupportedException( dataIn.type );
    }

    private Func<byte [ ]>? MarshalType( Type type, object dataIn )
    {
        if( type == typeof( int ) )
        {
            return () => _funcMarshallerFactory.Create<int>( ).Marshal( ( int )dataIn );
        }

        return null;
    }
}