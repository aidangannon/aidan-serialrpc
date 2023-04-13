namespace Aidan.SerialRPC.DynamicProxies;

public abstract class BaseProxy
{
    private readonly TestLogger _testLogger;
    private readonly IList<(Type type, object data)> _args;

    protected BaseProxy( TestLogger testLogger )
    {
        _testLogger = testLogger;
        _args = new List<(Type type, object data)>( );
    }

    protected int PublishShit( bool doesReturn = false )
    {
        foreach( var arg in _args )
        {
            _testLogger.Log( arg.type.Name );
        }

        _args.Clear( );

        return doesReturn ? Random.Shared.Next( 1, 6 ) : 0;
    }
    
    protected void AddStringArg( string arg ) => AddArg( arg );
    
    protected void AddIntArg( int arg ) => AddArg( arg );
    
    private void AddArg<T>(T data) => _args.Add( ( typeof( T ), data )! );
}