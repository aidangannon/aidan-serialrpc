using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.RawMarshalling;
using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.WrappedMarshalling;
using Aidan.SerialRPC.Core.Interfaces.Excluded;

namespace Aidan.SerialRPC.Marshalling.WrappedArgMarshalling;

public class WrappedStringArgMarshaller : BaseWrappedArgMarshaller<string>, IWrappedStringArgMarshaller
{
    public WrappedStringArgMarshaller( IStringArgMarshaller marshaller,
        IWrappedArgMarshaller wrappedArgMarshaller )
        : base( marshaller, wrappedArgMarshaller )
    {
    }
}