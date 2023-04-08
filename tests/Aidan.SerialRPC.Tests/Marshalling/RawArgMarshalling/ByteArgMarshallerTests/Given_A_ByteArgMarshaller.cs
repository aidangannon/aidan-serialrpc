using Aidan.Common.Utils.Test;
using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.RawMarshalling;
using Aidan.SerialRPC.Marshalling.RawArgMarshalling;

namespace Aidan.SerialRPC.Tests.Marshalling.RawArgMarshalling.ByteArgMarshallerTests;

public abstract class Given_A_ByteArgMarshaller : GivenWhenThen<IByteArgMarshaller>
{
    protected override void Given( )
    {
        SUT = new ByteArgMarshaller( );
    }
}