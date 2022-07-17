using Aidan.SerialRPC.Core.Interfaces.Excluded;

namespace Aidan.SerialRPC.Core.Interfaces.Contract.Marshalling.WrappedMarshalling;

/// <summary>
/// if any args are null, it converts to empty array of bytes, otherwise dispatch to the marshaller
/// </summary>
public interface INullConvertMarshaller : IFuncMarshaller<(object dataIn, Func<byte[]> marshaller)>
{
}