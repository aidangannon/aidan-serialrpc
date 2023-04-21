using Aidan.Common.Utils.Test;
using Aidan.SerialRPC.Core.Interfaces.Excluded.Marshalling;
using Aidan.SerialRPC.Marshalling.WrappedArgMarshalling;

namespace Aidan.SerialRPC.Tests.Marshalling.WrappedArgMarshalling.WrappedArgMarshallerTests;

public abstract class Given_A_WrappedArgMarshaller : GivenWhenThen<IWrappedArgMarshaller>
{
    protected override void Given( )
    {
        SUT = new WrappedArgMarshaller( );
    }
}