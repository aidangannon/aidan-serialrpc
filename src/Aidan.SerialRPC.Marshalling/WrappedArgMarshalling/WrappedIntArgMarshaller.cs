using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.RawMarshalling;
using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.WrappedMarshalling;
using Aidan.SerialRPC.Core.Interfaces.Excluded;

namespace Aidan.SerialRPC.Marshalling.WrappedArgMarshalling;

public class WrappedIntArgMarshaller : BaseWrappedArgMarshaller<int>, IWrappedIntArgMarshaller
{
    public WrappedIntArgMarshaller( IIntArgMarshaller marshaller,
        IWrappedArgMarshaller wrappedArgMarshaller )
        : base( marshaller, wrappedArgMarshaller )
    {
    }
}