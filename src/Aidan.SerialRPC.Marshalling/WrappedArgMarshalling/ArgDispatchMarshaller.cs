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
        return _funcMarshallerFactory.Create<int>( ).Marshal( ( int )dataIn.value );
    }
}