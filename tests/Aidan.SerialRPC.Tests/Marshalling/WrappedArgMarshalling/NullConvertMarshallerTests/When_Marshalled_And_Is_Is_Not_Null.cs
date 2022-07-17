using NSubstitute;
using NUnit.Framework;

namespace Aidan.SerialRPC.Tests.Marshalling.WrappedArgMarshalling.NullConvertMarshallerTests;

public class When_Marshalled_And_Is_Is_Not_Null : Given_A_NullConvertMarshaller
{
    private string _arg;
    private byte[] _result;
    private byte[] _bytesMarshalled;

    protected override void When( )
    {
        _bytesMarshalled = new byte[ ] { 0x04, 0x06, 0x17 };
        _arg = "hello world";
        MockMarshaller
            .Marshal( Arg.Any<string>( ) )
            .Returns( _bytesMarshalled );
        _result = SUT.Marshal( ( _arg, ( ) => MockMarshaller.Marshal( _arg ) ) );
    }

    [ Test ]
    public void Then_Data_Is_Marshalled_Via_Marshaller( )
    {
        CollectionAssert.AreEqual( _bytesMarshalled, _result );
    }
    
    [ Test ]
    public void Then_Marshaller_Is_Called_Once_With_Correct_Arg( )
    {
        MockMarshaller
            .Received( )
            .Marshal( _arg );
        MockMarshaller
            .Received( 1 )
            .Marshal( Arg.Any<string>( ) );
    }
}