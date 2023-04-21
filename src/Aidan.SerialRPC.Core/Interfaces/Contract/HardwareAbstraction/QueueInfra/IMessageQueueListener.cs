namespace Aidan.SerialRPC.Core.Interfaces.Contract.HardwareAbstraction.QueueInfra;

public interface IMessageQueueListener
{
    /// <summary>
    /// waits until message is completed on queue and result is on hardware return queue
    /// </summary>
    Task Listen( Guid messageId );
}