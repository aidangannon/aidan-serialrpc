using Aidan.Common.Utils.Test;
using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling;
using Aidan.SerialRPC.Marshalling.RawArgMarshalling;

namespace Aidan.SerialRPC.Tests.Marshalling.RawArgMarshalling.BoolArgParserTests;

public class Given_A_BoolArgParser : GivenWhenThen<IBoolArgParser>
{
    protected override void Given( )
    {
        SUT = new BoolArgParser( );
    }
}