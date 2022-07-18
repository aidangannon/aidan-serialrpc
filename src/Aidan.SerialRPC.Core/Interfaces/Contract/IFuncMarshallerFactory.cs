using Aidan.SerialRPC.Core.Interfaces.Excluded;

namespace Aidan.SerialRPC.Core.Interfaces.Contract;

public interface IFuncMarshallerFactory
{
    IFuncMarshaller<T> Create<T>( );
}