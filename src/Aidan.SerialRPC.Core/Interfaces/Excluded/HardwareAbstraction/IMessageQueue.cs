namespace Aidan.SerialRPC.Core.Interfaces.Excluded.HardwareAbstraction;

public interface IMessageQueue<T>
{
    event Action<T> MessageAdded;
    Task<T> Pop( );
    Task Enqueue( T message );
}