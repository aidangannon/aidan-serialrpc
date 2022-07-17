namespace Aidan.SerialRPC.Core.Interfaces.Excluded;

public interface IFuncMarshaller<TIn>
{
    byte [ ] Marshal( TIn dataIn );
}