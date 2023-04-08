namespace Aidan.SerialRPC.Core.Exceptions;

public class TypeNotSupportedException : Exception
{
    public TypeNotSupportedException( Type type ) : base($"type {type.Name} is not supported")
    {
    }
}