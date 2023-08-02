using System.Text;
using KekUploadServerApi.Console;
using KekUploadServerApi.Uploads;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace KekUploadServerApi;

/// <summary>
///     This class is a dummy implementation of <see cref="IKekUploadServer" />. It can be used to test plugins without
///     having to run a server.
///     If you want to test your plugin, you can use this class to create a dummy server and load your plugin into it.
///     For further testing, you can implement this class yourself and override the methods you need using the override
///     keyword. (e.g. <c>public override Task AddAndLoadPlugin(IPlugin plugin)</c>)
/// </summary>
public abstract class KekUploadDummyServer : IKekUploadServer
{
    public virtual Task AddAndLoadPlugin(IPlugin plugin)
    {
        Log($"AddAndLoadPlugin({plugin.Info.Name})");
        return Task.CompletedTask;
    }

    public virtual Task UnloadPlugin(IPlugin plugin)
    {
        Log($"UnloadPlugin({plugin.Info.Name})");
        return Task.CompletedTask;
    }

    public virtual IReadOnlyList<string> GetPluginNames()
    {
        Log("GetPluginNames()");
        return Array.Empty<string>();
    }

    public virtual string GetPluginDataPath(IPlugin plugin)
    {
        Log($"GetPluginDataPath({plugin.Info.Name})");
        return plugin.Info.Name;
    }

    public virtual string GetPluginDataPath(string pluginName)
    {
        Log($"GetPluginDataPath({pluginName})");
        return pluginName;
    }

    public virtual string GetPluginDataPath(PluginInfo pluginInfo)
    {
        Log($"GetPluginDataPath({pluginInfo.Name})");
        return pluginInfo.Name;
    }

    public virtual IPlugin? GetPlugin(string pluginName)
    {
        Log($"GetPlugin({pluginName})");
        return null;
    }

    public virtual string GetPluginPath(IPlugin plugin)
    {
        Log($"GetPluginPath({plugin.Info.Name})");
        return plugin.Info.Name;
    }

    public virtual bool IsPluginLoaded(string pluginName)
    {
        Log($"IsPluginLoaded({pluginName})");
        return false;
    }

    public virtual bool IsPluginEnabled(string pluginName)
    {
        Log($"IsPluginEnabled({pluginName})");
        return false;
    }

    public virtual ILogger<T> GetPluginLogger<T>() where T : IPlugin
    {
        Log($"GetPluginLogger<{typeof(T).Name}>()");
        return new NullLogger<T>();
    }

    public virtual ILogger<T> GetPluginLogger<T>(IPlugin plugin)
    {
        Log($"GetPluginLogger<{typeof(T).Name}>({plugin.Info.Name})");
        return new NullLogger<T>();
    }

    public virtual void RegisterLoggerProvider(IPlugin plugin, ILoggerProvider loggerProvider)
    {
        Log($"RegisterLoggerProvider({plugin.Info.Name}, {loggerProvider})");
    }

    public virtual T? GetConfigValue<T>(string key)
    {
        Log($"GetConfigValue<{typeof(T).Name}>({key})");
        return default;
    }

    public virtual object? GetConfigValue(string key)
    {
        Log($"GetConfigValue({key})");
        return null;
    }

    public virtual string? GetConfigValueString(string key)
    {
        Log($"GetConfigValueString({key})");
        return null;
    }

    public virtual void SetConfigValue<T>(string key, T value)
    {
        Log($"SetConfigValue<{typeof(T).Name}>({key}, {value})");
    }

    public virtual Task<IReadOnlyList<IUploadedItem>> GetUploads()
    {
        Log("GetUploads()");
        return Task.FromResult<IReadOnlyList<IUploadedItem>>(Array.Empty<IUploadedItem>());
    }

    public virtual Task<string> CreateUploadStream(string extension, string? name = null)
    {
        Log($"CreateUploadStream({extension}, {name})");
        return Task.FromResult(Guid.NewGuid().ToString());
    }

    public virtual Task TerminateUploadStream(string streamId)
    {
        Log($"TerminateUploadStream({streamId})");
        return Task.CompletedTask;
    }

    public virtual Task<bool> UploadChunk(string streamId, Stream requestBody, string? hash = null)
    {
        Log($"UploadChunk({streamId}, {requestBody}, {hash})");
        return Task.FromResult(true);
    }

    public virtual Task<bool> UploadChunk(string streamId, byte[] requestBody, string? hash = null)
    {
        Log($"UploadChunk({streamId}, {requestBody}, {hash})");
        return Task.FromResult(true);
    }

    public virtual Task<bool> UploadChunk(string streamId, string requestBody, string? hash = null)
    {
        Log($"UploadChunk({streamId}, {requestBody}, {hash})");
        return Task.FromResult(true);
    }

    public virtual Task<bool> UploadChunk(string streamId, string requestBody, Encoding encoding, string? hash = null)
    {
        Log($"UploadChunk({streamId}, {requestBody}, {encoding}, {hash})");
        return Task.FromResult(true);
    }

    public virtual Task<string?> FinalizeUpload(string streamId, string? hash = null)
    {
        Log($"FinalizeUpload({streamId}, {hash})");
        return Task.FromResult<string?>(Guid.NewGuid().ToString());
    }

    public virtual bool DoesUploadStreamExist(string streamId)
    {
        Log($"DoesUploadStreamExist({streamId})");
        return false;
    }

    public virtual Task<IUploadItem?> GetUploadItem(string streamId)
    {
        Log($"GetUploadItem({streamId})");
        return Task.FromResult<IUploadItem?>(null);
    }

    public virtual Task<IUploadedItem?> GetUploadedItem(string uploadId)
    {
        Log($"GetUploadedItem({uploadId})");
        return Task.FromResult<IUploadedItem?>(null);
    }

    public virtual Task<IEnumerable<string>> GetMimeType(string extension)
    {
        Log($"GetMimeType({extension})");
        return Task.FromResult<IEnumerable<string>>(Array.Empty<string>());
    }

    public virtual Task<Stream?> GetUploadedFileStream(string uploadId)
    {
        Log($"GetUploadedFileStream({uploadId})");
        return Task.FromResult<Stream?>(null);
    }

    public virtual Task<byte[]?> GetUploadedFileBytes(string uploadId)
    {
        Log($"GetUploadedFileBytes({uploadId})");
        return Task.FromResult<byte[]?>(null);
    }

    public virtual Task<string?> GetUploadedFileString(string uploadId)
    {
        Log($"GetUploadedFileString({uploadId})");
        return Task.FromResult<string?>(null);
    }

    public virtual Task<string?> GetUploadedFileString(string uploadId, Encoding encoding)
    {
        Log($"GetUploadedFileString({uploadId}, {encoding})");
        return Task.FromResult<string?>(null);
    }

    public virtual void Shutdown(IPlugin plugin, string reason = "Plugin initiated shutdown", TimeSpan delay = default)
    {
        Log($"Shutdown({plugin.Info.Name}, {reason}, {delay})");
    }

    public virtual event EventHandler<UploadStreamCreatedEventArgs>? UploadStreamCreated
    {
        add => Log("UploadStreamCreated += " + value);
        remove => Log("UploadStreamCreated -= " + value);
    }

    public virtual event EventHandler<ChunkUploadedEventArgs>? ChunkUploaded
    {
        add => Log("ChunkUploaded += " + value);
        remove => Log("ChunkUploaded -= " + value);
    }

    public virtual event EventHandler<UploadStreamFinalizedEventArgs>? UploadStreamFinalized
    {
        add => Log("UploadStreamFinalized += " + value);
        remove => Log("UploadStreamFinalized -= " + value);
    }

    public virtual event EventHandler<ConsoleLineWrittenEventArgs>? ConsoleLineWritten
    {
        add => Log("ConsoleLineWritten += " + value);
        remove => Log("ConsoleLineWritten -= " + value);
    }

    protected static void Log(string message)
    {
        System.Console.WriteLine("[KekUploadDummyServer] " + message);
    }
}