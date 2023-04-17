namespace Aidan.SerialRPC.Core.Interfaces.Contract.Common;

public interface IIocServiceResolverWrapper
{
    TService Wrap<TService>( Func<TService> serviceResolver );
}