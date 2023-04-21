using Aidan.SerialRPC.Core.Dtos;

namespace Aidan.SerialRPC.Core.Interfaces.Contract.HardwareAbstraction.QueueInfra;

/// <summary>
/// listens to the queue
/// </summary>
public interface IHardwareMessageReciever
{
    void HandleMessage( Message message );
}