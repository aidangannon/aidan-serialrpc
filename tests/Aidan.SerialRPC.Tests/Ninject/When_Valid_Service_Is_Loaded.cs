using NUnit.Framework;

namespace Aidan.SerialRPC.Tests.Ninject;

public class When_Valid_Service_Is_Loaded : Given_A_FuncMarshallerFactory
{
    [Test]
    public void Then( )
    {
        try
        {
            var factory = SUT.Create<Guid>( );
        }
        catch( Exception e )
        {
            
        }
    }
}