namespace Aidan.SerialRPC.DynamicProxies;

public class TestLogger
{
    public void Log( string message, bool returnVal = false )
    {
        Console.WriteLine(message);
    }
}