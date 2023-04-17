using Aidan.Common.Utils.Test;
using Aidan.SerialRPC.Common.IoC;
using Aidan.SerialRPC.Core.Interfaces.Contract.Common;

namespace Aidan.SerialRPC.Tests.Common;

public abstract class Given_An_IocServiceResolverWrapper : GivenWhenThen<IIocServiceResolverWrapper>
{
    protected override void Given( )
    {
        SUT = new NinjectServiceResolverWrapper( );
    }
}