using Aidan.SerialRPC.Core.Interfaces.Excluded;

namespace Aidan.SerialRPC.Tests.DynamicProxies;

public interface ITestInterface
{
    void DoSomething();
    public void DoSomethingElse( byte byte1, byte byte2 );
}

class TestInterface : ITestInterface
{
    private readonly IWrappedArgMarshaller _wrappedArgMarshaller;

    public TestInterface( IWrappedArgMarshaller wrappedArgMarshaller )
    {
        _wrappedArgMarshaller = wrappedArgMarshaller;
    }
    
    public void DoSomething( )
    {
        Console.WriteLine("test");
    }

    public void DoSomethingElse( byte byte1, byte byte2 )
    {
        _wrappedArgMarshaller.Marshal( new [ ] { byte1, byte2 } );
    }
}