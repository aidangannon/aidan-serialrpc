using Aidan.Common.Utils.Test;
using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.WrappedMarshalling;
using Aidan.SerialRPC.Core.Interfaces.Excluded;
using Aidan.SerialRPC.Marshalling.WrappedArgMarshalling;
using NSubstitute;

namespace Aidan.SerialRPC.Tests.Marshalling.WrappedArgMarshalling.NullConvertMarshallerTests;

public abstract class Given_A_NullConvertMarshaller : GivenWhenThen<INullConvertMarshaller>
{
    protected IFuncMarshaller<string> MockMarshaller;

    protected override void Given( )
    {
        MockMarshaller = Substitute.For<IFuncMarshaller<string>>( );
        SUT = new NullConvertMarshaller( );
    }
}