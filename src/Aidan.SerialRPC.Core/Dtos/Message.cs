using Aidan.SerialRPC.Core.Enums;

namespace Aidan.SerialRPC.Core.Dtos;

public class Message
{
    public byte[] Payload { get; set; }
    public Guid Id { get; set; }
    public int DeliveryCount { get; set; }
    public MessagePriority Priority { get; set; }
}