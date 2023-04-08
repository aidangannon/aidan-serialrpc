using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.WrappedMarshalling;
using AutoFixture;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Aidan.SerialRPC.Tests.Marshalling.WrappedArgMarshalling.ArgDispatchMarshallerTests;

public class When_Dispatched_And_Data_Is_A_Byte : Given_An_ArgDispatchMarshaller
{
    private IGenericWrappedArgMarshaller<byte> _wrappedMarshaller;
    private byte[] _result;
    private byte[] _serialisedString;
    private byte _input;
    private Fixture _fixture = new();

    protected override void When( )
    {
        _input = _fixture.Create<byte>(  );
        _serialisedString = _fixture.CreateMany<byte>( ).ToArray( );
        _wrappedMarshaller = Substitute.For<IGenericWrappedArgMarshaller<byte>>( );
        _wrappedMarshaller
            .Marshal( _input )
            .Returns( _serialisedString );
        MockFuncMarshallerFactory
            .Create<byte>( )
            .Returns( _wrappedMarshaller );
        _result = SUT.Marshal( ( typeof( byte ), _input ) );
    }

    [Test]
    public void Then_Result_Is_Serialised_Byte( )
    {
        _result.Should( ).BeEquivalentTo( _serialisedString );
    }
    
    [Test]
    public void Then_Byte_Is_Marshalled_Once( )
    {
        _wrappedMarshaller.Received( 1 ).Marshal( Arg.Any<byte>( ) );
    }
}