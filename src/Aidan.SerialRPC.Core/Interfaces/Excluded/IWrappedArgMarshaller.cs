namespace Aidan.SerialRPC.Core.Interfaces.Excluded;

/// <summary>
/// wraps the arg parsing inside start and end blocks
/// </summary>
public interface IWrappedArgMarshaller : IFuncMarshaller<Func<byte [ ]>>
{
}