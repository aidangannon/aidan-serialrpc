namespace Aidan.SerialRPC.Core.DTOs;

public class Function
{
    public IEnumerable<(Type type, object value)> Args { get; set; }
    public string Identifier { get; set; }
}