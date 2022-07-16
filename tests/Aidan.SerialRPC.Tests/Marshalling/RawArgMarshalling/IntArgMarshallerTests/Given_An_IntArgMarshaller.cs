using Aidan.Common.Utils.Test;
using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.RawMarshalling;
using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.WrappedMarshalling;
using Aidan.SerialRPC.Marshalling.RawArgMarshalling;
using NSubstitute;

namespace Aidan.SerialRPC.Tests.Marshalling.RawArgMarshalling.IntArgMarshallerTests;

public class Given_An_IntArgMarshaller : GivenWhenThen<IIntArgMarshaller>
{
    protected IPaddingInterleaveMarshaller MockPaddingInterleaveMarshaller;

    protected override void Given( )
    {
        MockPaddingInterleaveMarshaller = Substitute.For<IPaddingInterleaveMarshaller>( );
        SUT = new IntArgMarshaller( MockPaddingInterleaveMarshaller );
    }
}