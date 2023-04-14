using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.WrappedMarshalling;
using AutoFixture;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Aidan.SerialRPC.Tests.Marshalling.WrappedArgMarshalling.ArgDispatchMarshallerTests;

public class When_Dispatched_And_Data_Is_A_Bool : Given_An_ArgDispatchMarshaller
{
    private IGenericWrappedArgMarshaller<bool> _wrappedMarshaller;
    private byte[] _result;
    private byte[] _serialisedString;
    private bool _input;
    private Fixture _fixture = new();

    protected override void When( )
    {
        _input = _fixture.Create<bool>(  );
        _serialisedString = _fixture.CreateMany<byte>( ).ToArray( );
        _wrappedMarshaller = Substitute.For<IGenericWrappedArgMarshaller<bool>>( );
        _wrappedMarshaller
            .Marshal( _input )
            .Returns( _serialisedString );
        MockFuncMarshallerFactory
            .Create<bool>( )
            .Returns( _wrappedMarshaller );
        _result = SUT.Marshal( _input );
    }

    [Test]
    public void Then_Result_Is_Serialised_Bool( )
    {
        _result.Should( ).BeEquivalentTo( _serialisedString );
    }
    
    [Test]
    public void Then_Bool_Is_Marshalled_Once( )
    {
        _wrappedMarshaller.Received( 1 ).Marshal( Arg.Any<bool>( ) );
    }
}