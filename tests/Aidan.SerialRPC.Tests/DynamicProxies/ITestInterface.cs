using Aidan.SerialRPC.DynamicProxies;

namespace Aidan.SerialRPC.Tests.DynamicProxies;

public interface ITestInterface
{
    void OperationOne(int arg1);
    void OperationTwo(int arg1, string arg2);
    int OperationThree(string arg1, string arg2);
}

public class TestInterface : BaseProxy, ITestInterface
{
    public TestInterface( TestLogger logger ) : base( logger )
    {
    }

    public void OperationOne( int arg1 )
    {
        AddIntArg( arg1 );
        PublishShit( );
    }

    public void OperationTwo( int arg1, string arg2 )
    {
        AddIntArg( arg1 );
        AddStringArg( arg2 );
        PublishShit( );
    }

    public int OperationThree( string arg1, string arg2 )
    {
        AddStringArg( arg1 );
        AddStringArg( arg2 );
        return PublishShit( true );
    }
}