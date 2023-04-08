using Aidan.Common.Core.Interfaces.Excluded;
using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.WrappedMarshalling;

namespace Aidan.SerialRPC.Core.Interfaces.Contract;

public interface IFuncMarshallerFactory : IFactory
{
    IGenericWrappedArgMarshaller<T> Create<T>( );
}