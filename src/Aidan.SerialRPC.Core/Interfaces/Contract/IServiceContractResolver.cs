using Aidan.SerialRPC.Core.DTOs;

namespace Aidan.SerialRPC.Core.Interfaces.Contract;

public interface IServiceContractResolver
{
    public IEnumerable<Function> Value { get; }
}