using Aidan.SerialRPC.Core.Interfaces.Excluded;
using Aidan.SerialRPC.Marshalling.WrappedArgMarshalling;

namespace Aidan.SerialRPC.Tests.Marshalling.WrappedArgMarshalling.BaseArgMarshallerTests;

public class FakeWrappedArgMarshaller : BaseWrappedArgMarshaller<object>
{
    public FakeWrappedArgMarshaller( IFuncMarshaller<object> marshaller,
        IWrappedArgMarshaller wrappedArgMarshaller )
        : base( marshaller, wrappedArgMarshaller )
    {
    }
}