using Aidan.SerialRPC.Core.Interfaces.Excluded;

namespace Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling;

/// <summary>
/// dispatches to the valid arg marshaller
/// </summary>
public interface IArgDispatchMarshaller : IFuncMarshaller<(Type type, object value)>
{
}