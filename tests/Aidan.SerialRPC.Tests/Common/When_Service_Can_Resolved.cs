using FluentAssertions;
using NUnit.Framework;

namespace Aidan.SerialRPC.Tests.Common;

public class When_Service_Can_Resolved : Given_An_IocServiceResolverWrapper
{
    private TestService _service;
    private Func<TestService> _wrapper;

    protected override void When( )
    {
        _wrapper = () => _service = SUT.Wrap( ( ) => new TestService( ) );
    }

    [Test]
    public void Then_Wrapper_Does_Not_Throw( )
    {
        _wrapper.Should( ).NotThrow( );
    }
    
    [Test]
    public void Then_Service_Is_Returned( )
    {
        var service = _wrapper( );
        service.Should( ).NotBeNull( );
    }
}