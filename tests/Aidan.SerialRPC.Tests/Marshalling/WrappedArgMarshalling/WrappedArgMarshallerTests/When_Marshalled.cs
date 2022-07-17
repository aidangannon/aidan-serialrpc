using Aidan.SerialRPC.Core.Interfaces.Excluded;
using NSubstitute;
using NUnit.Framework;

namespace Aidan.SerialRPC.Tests.Marshalling.WrappedArgMarshalling.WrappedArgMarshallerTests;

public class When_Marshalled : Given_A_WrappedArgMarshaller
{
    private IFuncMarshaller<object> _marshaller;
    private byte[] _result;

    protected override void When( )
    {
        _marshaller = Substitute.For<IFuncMarshaller<object>>( );
        _marshaller
            .Marshal( Arg.Any<object>( ) )
            .Returns( new byte [ ] { 0x05, 0xF0, 0x80 } );
        _result = SUT.Marshal( ( ) => _marshaller.Marshal( null ) );
    }

    [ Test ]
    public void Then_Marshalled_Bytes_Are_Wrapped_With_Start_And_End_Bytes( )
    {
        CollectionAssert.AreEqual( new byte [ ] { 0xFF, 0x05, 0xF0, 0x80, 0x00 }, _result );
    }
    
    [ Test ]
    public void Then_Marshaller_Is_Called_Once( )
    {
        _marshaller
            .Received( 1 )
            .Marshal( Arg.Any<object>( ) );
    }
}