using Aidan.SerialRPC.Core.Exceptions;
using FluentAssertions;
using Ninject;
using NUnit.Framework;

namespace Aidan.SerialRPC.Tests.Common;

public class When_Service_Cannot_Resolved : Given_An_IocServiceResolverWrapper
{
    [Test]
    public void Then_Service_Not_Found_Exception_Is_Thrown( )
    {
        var wrapper = () => SUT.Wrap<TestService>( ( ) => throw new ActivationException() );
        wrapper.Should( ).Throw<ServiceNotFoundException>( );
    }
}