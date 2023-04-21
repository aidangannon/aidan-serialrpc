namespace Aidan.SerialRPC.Core.Dtos;

public class MessageReturn
{
    public Guid MessageId { get; set; }
    public byte[] Return { set; get; }
}