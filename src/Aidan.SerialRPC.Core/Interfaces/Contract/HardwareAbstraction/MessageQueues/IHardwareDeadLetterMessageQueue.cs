using Aidan.SerialRPC.Core.Dtos;
using Aidan.SerialRPC.Core.Interfaces.Excluded.HardwareAbstraction;

namespace Aidan.SerialRPC.Core.Interfaces.Contract.HardwareAbstraction.MessageQueues;

/// <summary>
/// priority queue for hardware messages that have been abandoned
/// </summary>
public interface IHardwareDeadLetterMessageQueue : IMessageQueue<Message>, IPeakableQueue<Message>
{
}