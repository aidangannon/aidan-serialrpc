namespace Aidan.SerialRPC.Core.Attributes;

/// <summary>
/// decorates functions to be declared as serial RPC functions
/// </summary>
[ AttributeUsage( AttributeTargets.Method ) ]
public class SerivceContractAttribute : Attribute
{
}