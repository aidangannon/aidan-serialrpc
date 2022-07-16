using Aidan.SerialRPC.Core.Interfaces.Excluded;

namespace Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.WrappedMarshalling;

/// <summary>
/// interleaves bits with padding when arg spans multiple bytes
/// </summary>
public interface IPaddingInterleaveMarshaller : IFuncMarshaller<byte[]>
{
}