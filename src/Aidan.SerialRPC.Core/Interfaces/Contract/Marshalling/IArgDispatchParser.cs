using Aidan.SerialRPC.Core.Interfaces.Excluded;

namespace Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling;

/// <summary>
/// dispatches to the valid arg parser
/// </summary>
public interface IArgDispatchParser : IFuncParser<(Type type, object value)>
{
}