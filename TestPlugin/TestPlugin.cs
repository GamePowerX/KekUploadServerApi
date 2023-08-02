using KekUploadServerApi;
using Microsoft.Extensions.Logging;

namespace TestPlugin;

public class TestPlugin : IPlugin
{
    private ILogger<TestPlugin> _logger = null!;
    private IKekUploadServer _server = null!;

    public Task Load(IKekUploadServer server)
    {
        _server = server;
        _logger = _server.GetPluginLogger<TestPlugin>();
        return Task.CompletedTask;
    }

    public Task Start()
    {
        _logger.LogInformation("TestPlugin started!");
        _server.SetConfigValue("TestPluginKey", "TestPluginValue" + DateTime.Now + "!");
        return Task.CompletedTask;
    }

    public Task Unload()
    {
        _logger.LogInformation("TestPlugin unloaded!");
        return Task.CompletedTask;
    }

    PluginInfo IPlugin.Info => new()
    {
        Name = "TestPlugin",
        Version = "1.0.0-test",
        Author = "GamePowerX",
        Description = "A test plugin for KekUploadServer"
    };

    public void TestMethod()
    {
        _logger.LogInformation("TestPlugin.TestMethod() called!");
    }
}