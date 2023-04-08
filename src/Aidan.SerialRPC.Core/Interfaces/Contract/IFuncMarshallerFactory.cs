using Aidan.Common.Core.Interfaces.Excluded;
using Aidan.SerialRPC.Core.Interfaces.Excluded;

namespace Aidan.SerialRPC.Core.Interfaces.Contract;

public interface IFuncMarshallerFactory : IFactory
{
    IFuncMarshaller<T> Create<T>( );
}