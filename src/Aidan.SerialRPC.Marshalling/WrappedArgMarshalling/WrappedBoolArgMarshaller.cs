﻿using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.RawMarshalling;
using Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.WrappedMarshalling;
using Aidan.SerialRPC.Core.Interfaces.Excluded.Marshalling;

namespace Aidan.SerialRPC.Marshalling.WrappedArgMarshalling;

public class WrappedBoolArgMarshaller : BaseWrappedArgMarshaller<bool>, IGenericWrappedArgMarshaller<bool>
{
    public WrappedBoolArgMarshaller( IBoolArgMarshaller marshaller,
        IWrappedArgMarshaller wrappedArgMarshaller )
        : base( marshaller, wrappedArgMarshaller )
    {
    }
}