using KekUploadServerApi;
using Microsoft.Extensions.Logging;
using TestPlugin;

namespace AnotherTestPlugin;

public class AnotherTestPlugin : IPlugin
{
    private ILogger<AnotherTestPlugin> _logger = null!;
    private IKekUploadServer _server = null!;

    public Task Load(IKekUploadServer server)
    {
        _server = server;
        _logger = _server.GetPluginLogger<AnotherTestPlugin>();
        _logger.LogInformation("AnotherTestPlugin loaded!");
        var testPlugin = _server.GetPlugin("TestPlugin");
        if (testPlugin == null)
        {
            _logger.LogError("TestPlugin not found!");
            return Task.CompletedTask;
        }

        TestClass.TestMethod(_logger);
        return Task.CompletedTask;
    }

    public Task Start()
    {
        _logger.LogInformation("AnotherTestPlugin started!");
        var testPlugin = _server.GetPlugin("TestPlugin");
        if (testPlugin == null)
        {
            _logger.LogError("TestPlugin not found!");
            return Task.CompletedTask;
        }

        var testPluginObj = (TestPlugin.TestPlugin)testPlugin;
        testPluginObj.TestMethod();
        return Task.CompletedTask;
    }

    public Task Unload()
    {
        _logger.LogInformation("AnotherTestPlugin unloaded!");
        return Task.CompletedTask;
    }

    PluginInfo IPlugin.Info => new()
    {
        Name = "AnotherTestPlugin",
        Version = "1.0.0-test",
        Author = "GamePowerX",
        Description = "Another test plugin for KekUploadServer",
        Dependencies = new[] { "TestPlugin" }
    };
}