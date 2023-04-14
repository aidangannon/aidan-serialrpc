using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.WrappedMarshalling;
using AutoFixture;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Aidan.SerialRPC.Tests.Marshalling.WrappedArgMarshalling.ArgDispatchMarshallerTests;

public class When_Dispatched_And_Data_Is_An_Int : Given_An_ArgDispatchMarshaller
{
    private byte[] _result;
    private IGenericWrappedArgMarshaller<int> _mockIntMarshaller;
    private byte[] _marshalledInt;

    protected override void When( )
    {
        _mockIntMarshaller = Substitute.For<IGenericWrappedArgMarshaller<int>>( );
        _marshalledInt = new Fixture( ).CreateMany<byte>( ).ToArray( );
        MockFuncMarshallerFactory.Create<int>( ).Returns( _mockIntMarshaller );
        _mockIntMarshaller.Marshal( 4 ).Returns( _marshalledInt );
        _result = SUT.Marshal( 4 );
    }

    [ Test ]
    public void Then_A_Marshalled_Int_Is_Returned( )
    {
        _result.Should( ).BeEquivalentTo( _marshalledInt );
    }
    
    [ Test ]
    public void Then_An_Int_Is_Marshalled( )
    {
        _mockIntMarshaller.Received( ).Marshal( Arg.Any<int>( ) );
    }
}