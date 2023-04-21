namespace Aidan.SerialRPC.Core.Interfaces.Excluded.Unmarshalling;

public interface IFuncUnmarshaller<T>
{
    T Unmarshall( byte [ ] dataIn );
}