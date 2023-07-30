# KekUploadServerApi - Plugin API for [KekUploadServer in C#](https://github.com/GamePowerX/KekUploadServer)
## How to use
### 1. Create a new project
Create a new project in your IDE or with the dotnet CLI.
### 2. Add the KekUploadServerApi package
Add the KekUploadServerApi package to your project.
#### dotnet CLI
```bash
dotnet add package GamePowerX.KekUploadServerApi
```
#### NuGet Package Manager
```
Install-Package GamePowerX.KekUploadServerApi
```
### 3. Create a new class
Create a new class that implements the `IPlugin` interface.
```csharp
using KekUploadServerApi;
using Microsoft.Extensions.Logging;

namespace TestPlugin;

public class TestPlugin : IPlugin
{
    private IKekUploadServer _server = null!;
    private ILogger<TestPlugin> _logger = null!;

    public Task Load(IKekUploadServer server)
    {
        _server = server;
        _logger = _server.GetPluginLogger<TestPlugin>();
        return Task.CompletedTask;
    }

    public Task Start()
    {
        _logger.LogInformation("TestPlugin started!");
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
```
### 4. Build the project
Build the project with your IDE or with the dotnet CLI.
### 5. Copy the plugin dll file into the plugins folder
Copy the plugin dll file into the plugins folder of your KekUploadServer installation.
### 6. Start the server
Start the server and check the console output for errors.
### 7. Enjoy your plugin
The plugin should now be loaded and you can use it.
## Dependency support
You can add dependencies to your plugin by specifying them in the `PluginInfo` class.
```csharp
PluginInfo IPlugin.Info => new() {
       Name = "AnotherTestPlugin",
       Version = "1.0.0-test",
       Author = "GamePowerX",
       Description = "Another test plugin for KekUploadServer",
       Dependencies = new[]{"TestPlugin"}
    };
```
## Contribute
You can contribute to this project by creating a pull request or by creating an issue.
## License
This project is licensed under the MIT license. See the [LICENSE](https://github.com/GamePowerX/KekUploadServerApi/blob/master/LICENSE) file for more information.
