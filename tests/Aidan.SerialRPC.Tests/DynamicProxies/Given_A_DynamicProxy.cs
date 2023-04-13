using Aidan.Common.Utils.Test;
using Aidan.SerialRPC.DynamicProxies;
using NUnit.Framework;

namespace Aidan.SerialRPC.Tests.DynamicProxies;

public class Given_A_DynamicProxy : GivenWhenThen<ITestInterface>
{
    protected override void Given( )
    {
        SUT = DynamicTypeGenerator.Build<ITestInterface>( );
    }

    [Test]
    public void Test( )
    {
        SUT.OperationOne( 1 );
        SUT.OperationTwo( 1, "" );
        var randomVar = SUT.OperationThree( "", "" );
    }
}