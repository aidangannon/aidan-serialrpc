namespace Aidan.SerialRPC.Core.Interfaces.Excluded.HardwareAbstraction;

public interface IPeakableQueue<T>
{
    Task<IEnumerable<T>> GetAll( );
    Task<T> RemoveAt( int index );
}