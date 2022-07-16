namespace Aidan.SerialRPC.Core.Interfaces.Excluded;

public interface IFuncParser<TIn>
{
    byte [ ] Parse( TIn dataIn );
}