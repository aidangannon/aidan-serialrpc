using Aidan.SerialRPC.Core.Dtos;
using Aidan.SerialRPC.Core.Interfaces.Excluded.HardwareAbstraction;

namespace Aidan.SerialRPC.Core.Interfaces.Contract.HardwareAbstraction.MessageQueues;

/// <summary>
/// queue for message results from the queue
/// </summary>
public interface IHardwareReturnMessageQueue : IMessageQueue<MessageReturn>, IPeakableQueue<MessageReturn>
{
}