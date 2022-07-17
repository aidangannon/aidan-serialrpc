using Aidan.Common.Utils.Test;
using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.WrappedMarshalling;
using Aidan.SerialRPC.Marshalling.WrappedArgMarshalling;

namespace Aidan.SerialRPC.Tests.Marshalling.WrappedArgMarshalling.PaddingInterleaveMarshallerTests;

public class Given_A_F0PaddingInterleaveMarshaller : GivenWhenThen<IPaddingInterleaveMarshaller>
{
    protected override void Given( )
    {
        SUT = new F0PaddingInterleaveMarshaller( );
    }
}