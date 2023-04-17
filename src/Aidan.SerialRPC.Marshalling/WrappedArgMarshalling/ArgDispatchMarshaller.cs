using Aidan.SerialRPC.Core.Exceptions;
using Aidan.SerialRPC.Core.Interfaces.Contract;
using Aidan.SerialRPC.Core.Interfaces.Contract.Common;
using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling;

namespace Aidan.SerialRPC.Marshalling.WrappedArgMarshalling;

public class ArgDispatchMarshaller : IArgDispatchMarshaller
{
    private readonly IFuncMarshallerFactory _funcMarshallerFactory;
    private readonly IIocServiceResolverWrapper _iocServiceResolverWrapper;

    public ArgDispatchMarshaller( IFuncMarshallerFactory funcMarshallerFactory,
        IIocServiceResolverWrapper iocServiceResolverWrapper )
    {
        _funcMarshallerFactory = funcMarshallerFactory;
        _iocServiceResolverWrapper = iocServiceResolverWrapper;
    }

    public byte [ ] Marshal<T>( T dataIn )
    {
        var type = typeof( T );
        try
        {
            var wrappedArgMarshaller = _iocServiceResolverWrapper
                .Wrap( ( ) => _funcMarshallerFactory
                    .Create<T>( ) );
            return wrappedArgMarshaller.Marshal( dataIn );
        }
        catch( ServiceNotFoundException )
        {
            throw new TypeNotSupportedException( type );
        }
    }
}