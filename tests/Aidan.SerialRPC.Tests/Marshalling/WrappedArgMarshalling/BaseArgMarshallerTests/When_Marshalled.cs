using NSubstitute;
using NUnit.Framework;

namespace Aidan.SerialRPC.Tests.Marshalling.WrappedArgMarshalling.BaseArgMarshallerTests;

public class When_Marshalled : Given_A_FakeWrappedArgMarshaller
{
    private byte[] _result;
    private byte [ ] _rawBytes;
    private byte [ ] _wrappedBytes;

    protected override void When( )
    {
        _rawBytes = Array.Empty<byte>();
        MockFuncMarshaller
            .Marshal( Arg.Any<bool>( ) )
            .Returns( _rawBytes );
        _wrappedBytes = new byte[ ] { 0xFF, 0x00 };
        MockWrappedArgMarshaller
            .Marshal( Arg.Any<byte [ ]>( ) )
            .Returns( _wrappedBytes );
        _result = SUT.Marshal( null );
    }

    [ Test ]
    public void Then_Marshaller_Was_Called_Once_With_Arg( )
    {
        MockFuncMarshaller
            .Received( )
            .Marshal( null );
        MockFuncMarshaller
            .Received( 1 )
            .Marshal( Arg.Any<object>( ) );
    }
    
    [ Test ]
    public void Then_Wrapper_Was_Called_With_Result_From_Marshaller( )
    {
        MockWrappedArgMarshaller
            .Received( )
            .Marshal( Arg.Is<byte [ ]>( b => b.SequenceEqual( _rawBytes ) ) );
        MockWrappedArgMarshaller
            .Received( 1 )
            .Marshal( Arg.Any<byte[ ]>( ) );
    }
    
    [ Test ]
    public void Then_Wrapped_Bytes_Are_Returned( )
    {
        CollectionAssert.AreEqual( _wrappedBytes, _result );
    }
}