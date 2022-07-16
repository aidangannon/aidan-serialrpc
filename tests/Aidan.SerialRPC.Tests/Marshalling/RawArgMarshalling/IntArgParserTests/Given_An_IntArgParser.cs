using Aidan.Common.Utils.Test;
using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling;
using Aidan.SerialRPC.Marshalling.RawArgMarshalling;
using NSubstitute;

namespace Aidan.SerialRPC.Tests.Marshalling.RawArgMarshalling.IntArgParserTests;

public class Given_An_IntArgParser : GivenWhenThen<IIntArgParser>
{
    protected IPaddingInterleaveParser MockPaddingInterleaveParser;

    protected override void Given( )
    {
        MockPaddingInterleaveParser = Substitute.For<IPaddingInterleaveParser>( );
        SUT = new IntArgParser( MockPaddingInterleaveParser );
    }
}