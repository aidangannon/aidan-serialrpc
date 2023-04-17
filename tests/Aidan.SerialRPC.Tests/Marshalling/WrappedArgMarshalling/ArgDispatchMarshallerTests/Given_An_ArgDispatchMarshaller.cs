using Aidan.Common.Utils.Test;
using Aidan.SerialRPC.Core.Interfaces.Contract;
using Aidan.SerialRPC.Core.Interfaces.Contract.Common;
using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling;
using Aidan.SerialRPC.Marshalling.WrappedArgMarshalling;
using NSubstitute;

namespace Aidan.SerialRPC.Tests.Marshalling.WrappedArgMarshalling.ArgDispatchMarshallerTests;

public abstract class Given_An_ArgDispatchMarshaller : GivenWhenThen<IArgDispatchMarshaller>
{
    protected IFuncMarshallerFactory MockFuncMarshallerFactory;
    protected IIocServiceResolverWrapper MockIocServiceResolverWrapper;

    protected override void Given( )
    {
        MockFuncMarshallerFactory = Substitute.For<IFuncMarshallerFactory>( );
        MockIocServiceResolverWrapper = Substitute.For<IIocServiceResolverWrapper>( );
        SUT = new ArgDispatchMarshaller( MockFuncMarshallerFactory, MockIocServiceResolverWrapper );
    }
}