using Aidan.SerialRPC.Core.Interfaces.Excluded;

namespace Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.WrappedMarshalling;

public interface IGenericWrappedArgMarshaller<T> : IFuncMarshaller<T>, IGenericWrappedArgMarshallerHeader
{
}