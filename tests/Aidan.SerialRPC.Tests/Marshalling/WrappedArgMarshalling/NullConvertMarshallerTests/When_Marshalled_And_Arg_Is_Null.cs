using NSubstitute;
using NUnit.Framework;

namespace Aidan.SerialRPC.Tests.Marshalling.WrappedArgMarshalling.NullConvertMarshallerTests;

public class When_Marshalled_And_Arg_Is_Null : Given_A_NullConvertMarshaller
{
    private string _arg;
    private byte[] _result;

    protected override void When( )
    {
        _arg = null;
        _result = SUT.Marshal( ( _arg, ( ) => MockMarshaller.Marshal( _arg ) ) );
    }

    [ Test ]
    public void Then_Data_Is_Marshalled_Into_Empty_Bytes( )
    {
        CollectionAssert.AreEqual( Array.Empty<byte>( ), _result );
    }
    
    [ Test ]
    public void Then_Marshaller_Is_Not_Called( )
    {
        MockMarshaller
            .DidNotReceive( )
            .Marshal( Arg.Any<string>( ) );
    }
}