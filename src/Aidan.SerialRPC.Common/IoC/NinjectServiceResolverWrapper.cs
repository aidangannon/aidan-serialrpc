using Aidan.SerialRPC.Core.Exceptions;
using Aidan.SerialRPC.Core.Interfaces.Contract.Common;
using Ninject;

namespace Aidan.SerialRPC.Common.IoC;

public class NinjectServiceResolverWrapper : IIocServiceResolverWrapper
{
    public TService Wrap<TService>( Func<TService> serviceResolver )
    {
        try
        {
            return serviceResolver( );
        }
        catch( ActivationException )
        {
            throw new ServiceNotFoundException( typeof( TService ) );
        }
    }
}