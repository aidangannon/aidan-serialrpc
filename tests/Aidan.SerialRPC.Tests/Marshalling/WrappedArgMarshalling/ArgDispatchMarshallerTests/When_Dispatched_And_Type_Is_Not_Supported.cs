using Aidan.SerialRPC.Core.Exceptions;
using FluentAssertions;
using NUnit.Framework;

namespace Aidan.SerialRPC.Tests.Marshalling.WrappedArgMarshalling.ArgDispatchMarshallerTests;

public class When_Dispatched_And_Type_Is_Not_Supported : Given_An_ArgDispatchMarshaller
{
    [ TestCase( typeof( Guid ), "type Guid is not supported" ) ]
    [ TestCase( typeof( void ), "type void is not supported" ) ]
    public void Then_( Type type, string message )
    {
        var sutCall = () => SUT.Marshal( ( type, null! ) );
        sutCall.Should( ).Throw<TypeNotSupportedException>( message );
    }
}