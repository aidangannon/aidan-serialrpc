using Aidan.SerialRPC.Core.Interfaces.Excluded.Marshalling;

namespace Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.WrappedMarshalling;

public interface IGenericWrappedArgMarshaller<T> : IFuncMarshaller<T>, IGenericWrappedArgMarshallerHeader
{
}