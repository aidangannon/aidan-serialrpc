using Aidan.Common.Utils.Test;
using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.RawMarshalling;
using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.WrappedMarshalling;
using Aidan.SerialRPC.Marshalling.RawArgMarshalling;
using NSubstitute;

namespace Aidan.SerialRPC.Tests.Marshalling.RawArgMarshalling.StringArgMarshallerTests;

public class Given_A_UTF8StringArgMarshaller : GivenWhenThen<IStringArgMarshaller>
{
    protected IPaddingInterleaveMarshaller MockPaddingInterleaveMarshaller;

    protected override void Given( )
    {
        MockPaddingInterleaveMarshaller = Substitute.For<IPaddingInterleaveMarshaller>( );
        SUT = new Utf8StringArgMarshaller( MockPaddingInterleaveMarshaller );
    }
}