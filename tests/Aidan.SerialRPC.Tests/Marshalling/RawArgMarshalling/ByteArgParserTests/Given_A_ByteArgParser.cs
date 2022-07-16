using Aidan.Common.Utils.Test;
using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling;
using Aidan.SerialRPC.Marshalling.RawArgMarshalling;

namespace Aidan.SerialRPC.Tests.Marshalling.RawArgMarshalling.ByteArgParserTests;

public class Given_A_ByteArgParser : GivenWhenThen<IByteArgParser>
{
    protected override void Given( )
    {
        SUT = new ByteArgParser( );
    }
}