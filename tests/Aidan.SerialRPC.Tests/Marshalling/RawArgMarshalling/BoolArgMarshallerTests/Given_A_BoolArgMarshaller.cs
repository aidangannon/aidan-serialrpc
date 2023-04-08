using Aidan.Common.Utils.Test;
using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.RawMarshalling;
using Aidan.SerialRPC.Marshalling.RawArgMarshalling;

namespace Aidan.SerialRPC.Tests.Marshalling.RawArgMarshalling.BoolArgMarshallerTests;

public abstract class Given_A_BoolArgMarshaller : GivenWhenThen<IBoolArgMarshaller>
{
    protected override void Given( )
    {
        SUT = new BoolArgMarshaller( );
    }
}