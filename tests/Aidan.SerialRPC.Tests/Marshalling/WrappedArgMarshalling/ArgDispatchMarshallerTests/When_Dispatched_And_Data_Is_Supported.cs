using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.WrappedMarshalling;
using AutoFixture;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Aidan.SerialRPC.Tests.Marshalling.WrappedArgMarshalling.ArgDispatchMarshallerTests;

public class When_Dispatched_And_Data_Is_Supported : Given_An_ArgDispatchMarshaller
{
    private IGenericWrappedArgMarshaller<string> _wrappedMarshaller;
    private byte[] _result;
    private byte[] _serialisedString;
    private string _input;
    private Fixture _fixture = new();

    protected override void When( )
    {
        _input = _fixture.Create<string>(  );
        _serialisedString = _fixture.CreateMany<byte>( ).ToArray( );
        _wrappedMarshaller = Substitute.For<IGenericWrappedArgMarshaller<string>>( );
        MockIocServiceResolverWrapper
            .Wrap( Arg.Any<Func<IGenericWrappedArgMarshaller<string>>>( ) )
            .Returns( _wrappedMarshaller );
        _wrappedMarshaller
            .Marshal( _input )
            .Returns( _serialisedString );
        MockFuncMarshallerFactory
            .Create<string>( )
            .Returns( _wrappedMarshaller );
        _result = SUT.Marshal( _input );
    }
    
    [Test]
    public void Then_Result_Is_Serialised_String( )
    {
        _result.Should( ).BeEquivalentTo( _serialisedString );
    }
    
    [Test]
    public void Then_String_Is_Marshalled_Once( )
    {
        _wrappedMarshaller.Received( 1 ).Marshal( Arg.Any<string>( ) );
    }
}