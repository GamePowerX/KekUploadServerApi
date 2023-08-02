using KekUploadServerApi;
using Microsoft.Extensions.Logging;

namespace AnotherTestPlugin;

public class TestDummyServerImpl : KekUploadDummyServer
{
    /// <summary>
    ///     Here you can implement your own GetPlugin method.
    ///     So you can test your plugin needing dependencies without having to run a server.
    /// </summary>
    /// <param name="name">The name of the plugin you want to get</param>
    /// <returns>Your desired plugin</returns>
    public override IPlugin? GetPlugin(string name)
    {
        switch (name)
        {
            case "TestPlugin":
                var plugin = new TestPlugin.TestPlugin();
                plugin.Load(this);
                return plugin;
            case "AnotherTestPlugin":
                return new AnotherTestPlugin();
            default:
                Log($"GetPlugin({name})");
                return null;
        }
    }

    /// <summary>
    ///     Or you can implement your own GetPluginLogger method.
    ///     So that the logger is not null.
    /// </summary>
    /// <typeparam name="T">The class you want to get the logger for</typeparam>
    /// <returns>Your desired logger</returns>
    public override ILogger<T> GetPluginLogger<T>()
    {
        // return a logger that does nothing instead of a null logger (which would throw an exception)
        return new Logger<T>(new LoggerFactory());
    }
}