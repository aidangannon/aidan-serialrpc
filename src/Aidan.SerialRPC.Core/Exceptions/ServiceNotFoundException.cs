using System.Reflection;

namespace Aidan.SerialRPC.Core.Exceptions;

public class ServiceNotFoundException : Exception
{
    public ServiceNotFoundException( MemberInfo type ) : base($"type {type.Name} cannot be resolved")
    {
    }
}