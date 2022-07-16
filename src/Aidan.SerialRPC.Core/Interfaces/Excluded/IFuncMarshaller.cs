namespace Aidan.SerialRPC.Core.Interfaces.Excluded;

public interface IFuncMarshaller<TIn>
{
    byte [ ] Parse( TIn dataIn );
}