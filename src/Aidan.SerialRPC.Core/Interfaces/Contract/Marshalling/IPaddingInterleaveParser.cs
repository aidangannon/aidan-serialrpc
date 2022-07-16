using Aidan.SerialRPC.Core.Interfaces.Excluded;

namespace Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling;

/// <summary>
/// interleaves bits with padding when arg spans multiple bytes
/// </summary>
public interface IPaddingInterleaveParser : IFuncParser<byte[]>
{
}