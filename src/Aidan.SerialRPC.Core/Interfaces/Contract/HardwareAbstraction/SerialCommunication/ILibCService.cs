﻿namespace Aidan.SerialRPC.Core.Interfaces.Contract.HardwareAbstraction.SerialCommunication;

public interface ILibCService
{
    int Open( string fileName, int mode );
    int Ioctl( int fd, int request, int data );
    int Read( int handle, byte [ ] data, int length );
    int Write( int handle, byte [ ] data, int length );
}