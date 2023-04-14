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

    public byte [ ] Marshal<T>( T dataIn )
    {
        var type = typeof( T );
        if( type == typeof( int ) )
        {
            return _funcMarshallerFactory.Create<T>( ).Marshal( dataIn );
        }
        if( type == typeof( string ) )
        {
            return _funcMarshallerFactory.Create<T>( ).Marshal( dataIn );
        }
        if( type == typeof( byte ) )
        {
            return _funcMarshallerFactory.Create<T>( ).Marshal( dataIn );
        }
        if( type == typeof( bool ) )
        {
            return _funcMarshallerFactory.Create<T>( ).Marshal( dataIn );
        }

        throw new TypeNotSupportedException( type );
    }
}