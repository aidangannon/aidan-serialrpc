namespace Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling;

/// <summary>
/// dispatches to the valid arg marshaller
/// </summary>
public interface IArgDispatchMarshaller
{
    byte [ ] Marshal<T>( T dataIn );
}