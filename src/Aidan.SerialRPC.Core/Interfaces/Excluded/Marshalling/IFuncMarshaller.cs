namespace Aidan.SerialRPC.Core.Interfaces.Excluded.Marshalling;

public interface IFuncMarshaller<TIn>
{
    byte [ ] Marshal( TIn dataIn );
}