using Aidan.SerialRPC.Core.Interfaces.Excluded;

namespace Aidan.SerialRPC.Marshalling.WrappedArgMarshalling;

public abstract class BaseWrappedArgMarshaller<T> : IFuncMarshaller<T>
{
    private readonly IFuncMarshaller<T> _marshaller;
    private readonly IWrappedArgMarshaller _wrappedArgMarshaller;

    protected BaseWrappedArgMarshaller( IFuncMarshaller<T> marshaller,
        IWrappedArgMarshaller wrappedArgMarshaller )
    {
        _marshaller = marshaller;
        _wrappedArgMarshaller = wrappedArgMarshaller;
    }

    public byte [ ] Marshal( T dataIn )
    {
        var bytes = _marshaller.Marshal( dataIn );
        return _wrappedArgMarshaller.Marshal( bytes );
    }
}