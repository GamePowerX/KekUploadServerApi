namespace AnotherTestPlugin;

/// <summary>
///     This program class is used to test the test plugin.
///     This class does not need to be implemented in your plugin.
///     This class tests the plugin by creating a dummy server and loading the plugin into it.
///     You can use this class to test your plugin without having to run a server.
/// </summary>
public class Program
{
    public static void Main()
    {
        var server = new TestDummyServerImpl();
        var plugin = new AnotherTestPlugin();
        plugin.Load(server).Wait();
        plugin.Start().Wait();
    }
}