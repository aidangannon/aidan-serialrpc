using Aidan.SerialRPC.Core.Dtos;

namespace Aidan.SerialRPC.Core.Interfaces.Contract.HardwareAbstraction.QueueInfra;

public interface IHardwareMessageSender
{
    MessageReturn SendAndWaitForReturn( Message message );
}