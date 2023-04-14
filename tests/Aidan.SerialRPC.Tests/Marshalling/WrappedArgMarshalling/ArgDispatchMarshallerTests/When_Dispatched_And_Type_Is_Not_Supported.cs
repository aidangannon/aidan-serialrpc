using System.Net;
using Aidan.SerialRPC.Core.Exceptions;
using FluentAssertions;
using NUnit.Framework;

namespace Aidan.SerialRPC.Tests.Marshalling.WrappedArgMarshalling.ArgDispatchMarshallerTests;

public class When_Dispatched_And_Type_Is_Not_Supported : Given_An_ArgDispatchMarshaller
{
    [Test]
    public void Then_Type_Not_Supported_Error_Is_Thrown()
    {
        var sutCall = () => SUT.Marshal( HttpStatusCode.Accepted );
        sutCall.Should( ).Throw<TypeNotSupportedException>( $"type HttpStatusCode is not supported" );
    }
}