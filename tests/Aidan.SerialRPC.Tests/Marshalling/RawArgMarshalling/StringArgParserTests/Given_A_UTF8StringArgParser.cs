using Aidan.Common.Utils.Test;
using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling;
using Aidan.SerialRPC.Marshalling.RawArgMarshalling;
using NSubstitute;

namespace Aidan.SerialRPC.Tests.Marshalling.RawArgMarshalling.StringArgParserTests;

public class Given_A_UTF8StringArgParser : GivenWhenThen<IStringArgParser>
{
    protected IPaddingInterleaveParser MockPaddingInterleaveParser;

    protected override void Given( )
    {
        MockPaddingInterleaveParser = Substitute.For<IPaddingInterleaveParser>( );
        SUT = new UTF8StringArgParser( MockPaddingInterleaveParser );
    }
}