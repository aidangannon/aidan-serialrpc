using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.RawMarshalling;
using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.WrappedMarshalling;
using Aidan.SerialRPC.Core.Interfaces.Excluded.Marshalling;

namespace Aidan.SerialRPC.Marshalling.WrappedArgMarshalling;

public class WrappedIntArgMarshaller : BaseWrappedArgMarshaller<int>, IGenericWrappedArgMarshaller<int>
{
    public WrappedIntArgMarshaller( IIntArgMarshaller marshaller,
        IWrappedArgMarshaller wrappedArgMarshaller )
        : base( marshaller, wrappedArgMarshaller )
    {
    }
}