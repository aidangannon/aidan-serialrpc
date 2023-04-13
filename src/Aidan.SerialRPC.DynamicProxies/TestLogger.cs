namespace Aidan.SerialRPC.DynamicProxies;

public class TestLogger
{
    public int Log( string message, bool returnVal = false )
    {
        Console.WriteLine(message);
        return returnVal ? 1 : 0;
    }
}