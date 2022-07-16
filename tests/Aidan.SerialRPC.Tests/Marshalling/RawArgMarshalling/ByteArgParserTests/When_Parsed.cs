﻿using NUnit.Framework;

namespace Aidan.SerialRPC.Tests.Marshalling.RawArgMarshalling.ByteArgParserTests;

public class When_Parsed : Given_A_ByteArgParser
{
    [ Test ]
    public void Then_Byte_Input_Gets_Put_Into_An_Array( )
    {
        const byte byteIn = 0x05;
        CollectionAssert.AreEqual( new [ ] { byteIn }, SUT.Parse( byteIn ) );
    }
}