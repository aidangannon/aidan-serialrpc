using Aidan.SerialRPC.Core.Interfaces.Excluded;

namespace Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.WrappedMarshalling;

public interface IWrappedIntArgMarshaller : IFuncMarshaller<int>
{
}

public class TestWrappedIntArgMarshaller : IWrappedIntArgMarshaller
{
    public byte [ ] Marshal( int dataIn ) { throw new NotImplementedException( ); }
}