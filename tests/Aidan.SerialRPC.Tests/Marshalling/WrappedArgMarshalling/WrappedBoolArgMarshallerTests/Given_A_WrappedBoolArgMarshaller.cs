﻿using Aidan.Common.Utils.Test;
using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.RawMarshalling;
using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.WrappedMarshalling;
using Aidan.SerialRPC.Core.Interfaces.Excluded.Marshalling;
using Aidan.SerialRPC.Marshalling.WrappedArgMarshalling;
using NSubstitute;

namespace Aidan.SerialRPC.Tests.Marshalling.WrappedArgMarshalling.WrappedBoolArgMarshallerTests;

public abstract class Given_A_WrappedBoolArgMarshaller : GivenWhenThen<IGenericWrappedArgMarshaller<bool>>
{
    private IWrappedArgMarshaller _mockWrappedArgMarshaller;
    protected IBoolArgMarshaller MockBoolArgMarshaller;

    protected override void Given( )
    {
        _mockWrappedArgMarshaller = Substitute.For<IWrappedArgMarshaller>( );
        MockBoolArgMarshaller = Substitute.For<IBoolArgMarshaller>( );
        SUT = new WrappedBoolArgMarshaller( MockBoolArgMarshaller, _mockWrappedArgMarshaller );
    }
}