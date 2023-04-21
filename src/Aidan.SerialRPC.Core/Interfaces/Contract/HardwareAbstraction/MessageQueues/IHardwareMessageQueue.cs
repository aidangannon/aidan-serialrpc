using Aidan.SerialRPC.Core.Dtos;
using Aidan.SerialRPC.Core.Interfaces.Excluded.HardwareAbstraction;

namespace Aidan.SerialRPC.Core.Interfaces.Contract.HardwareAbstraction.MessageQueues;

/// <summary>
/// priority queue for hardware messages
/// </summary>
public interface IHardwareMessageQueue : IMessageQueue<Message>, IPeakableQueue<Message>
{
}