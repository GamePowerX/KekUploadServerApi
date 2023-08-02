using System.Text;
using KekUploadServerApi.Console;
using KekUploadServerApi.Uploads;
using Microsoft.Extensions.Logging;

namespace KekUploadServerApi;

/// <summary>
///     The main interface for plugins to interact with the server.
///     This interface is used by plugins to interact with the server.
/// </summary>
public interface IKekUploadServer
{
    /// <summary>
    ///     Adds a plugin to the server and loads it.
    /// </summary>
    /// <param name="plugin">The plugin to add and load.</param>
    Task AddAndLoadPlugin(IPlugin plugin);

    /// <summary>
    ///     Unloads a plugin from the server.
    /// </summary>
    /// <param name="plugin">The plugin to unload.</param>
    Task UnloadPlugin(IPlugin plugin);

    /// <summary>
    ///     Gets a list of all plugins names.
    /// </summary>
    /// <returns>A list of all plugins names.</returns>
    IReadOnlyList<string> GetPluginNames();

    /// <summary>
    ///     Gets the data path for a plugin.
    ///     This is where plugins should store their data.
    /// </summary>
    /// <param name="plugin">The plugin to get the data path for.</param>
    /// <returns>The data path for the plugin.</returns>
    string GetPluginDataPath(IPlugin plugin);

    /// <summary>
    ///     Gets the data path for a plugin using the plugin's name.
    ///     This is where plugins should store their data.
    /// </summary>
    /// <param name="pluginName">The name of the plugin to get the data path for.</param>
    /// <returns>The data path for the plugin.</returns>
    string GetPluginDataPath(string pluginName);

    /// <summary>
    ///     Gets the data path for a plugin using the plugin's info.
    ///     This is where plugins should store their data.
    /// </summary>
    /// <param name="pluginInfo">The info of the plugin to get the data path for.</param>
    /// <returns>The data path for the plugin.</returns>
    string GetPluginDataPath(PluginInfo pluginInfo);

    /// <summary>
    ///     Gets the <see cref="IPlugin" /> object representing the plugin with the specified name.
    /// </summary>
    /// <param name="pluginName">The name of the plugin to get.</param>
    /// <returns>The plugin with the specified name or <c>null</c> if no plugin with the specified name exists.</returns>
    IPlugin? GetPlugin(string pluginName);

    /// <summary>
    ///     Gets the path to the plugin's assembly.
    /// </summary>
    /// <param name="plugin">The plugin to get the path for.</param>
    /// <returns>The path to the plugin's assembly.</returns>
    /// <example>path_to/KekUploadServer/plugins/MyPlugin.dll</example>
    string GetPluginPath(IPlugin plugin);

    /// <summary>
    ///     Returns whether a plugin is loaded.
    /// </summary>
    /// <param name="pluginName">The name of the plugin to check.</param>
    /// <remarks>
    ///     The plugin name is case-sensitive and should be the same as the <see cref="PluginInfo.Name" /> property of the
    ///     plugins <see cref="PluginInfo" /> class.
    /// </remarks>
    /// <returns><c>true</c> if the plugin is loaded, <c>false</c> otherwise.</returns>
    bool IsPluginLoaded(string pluginName);

    /// <summary>
    ///     Returns whether a plugin is enabled.
    /// </summary>
    /// <param name="pluginName">The name of the plugin to check.</param>
    /// <remarks>
    ///     The plugin name is case-sensitive and should be the same as the <see cref="PluginInfo.Name" /> property of the
    ///     plugins <see cref="PluginInfo" /> class.
    /// </remarks>
    /// <returns><c>true</c> if the plugin is enabled, <c>false</c> otherwise.</returns>
    bool IsPluginEnabled(string pluginName);

    /// <summary>
    ///     Gets the logger for the specified plugin.
    /// </summary>
    /// <typeparam name="T">The type of the plugin to get the logger for.</typeparam>
    /// <returns>The logger for the specified plugin.</returns>
    /// <remarks>This method can only be called with a type that implements <see cref="IPlugin" />.</remarks>
    ILogger<T> GetPluginLogger<T>() where T : IPlugin;

    /// <summary>
    ///     Gets the logger a logger for a class contained in the specified plugin.
    /// </summary>
    /// <typeparam name="T">The type of the class to get the logger for.</typeparam>
    /// <param name="plugin">The plugin to get the logger for.</param>
    /// <returns>The logger for the specified class.</returns>
    ILogger<T> GetPluginLogger<T>(IPlugin plugin);

    /// <summary>
    ///     Registers a logger provider from a plugin.
    /// </summary>
    /// <param name="plugin">The plugin to register the logger provider from.</param>
    /// <param name="loggerProvider">The logger provider to register.</param>
    void RegisterLoggerProvider(IPlugin plugin, ILoggerProvider loggerProvider);

    /// <summary>
    ///     This method gets a configuration value as the specified type.
    /// </summary>
    /// <typeparam name="T">The type of the configuration value to get.</typeparam>
    /// <param name="key">The key of the configuration value to get.</param>
    /// <returns>The configuration value or <c>default(T)</c> if the configuration value does not exist.</returns>
    T? GetConfigValue<T>(string key);

    /// <summary>
    ///     This method gets a configuration value as an object.
    /// </summary>
    /// <param name="key">The key of the configuration value to get.</param>
    /// <returns>The configuration value or <c>null</c> if the configuration value does not exist.</returns>
    object? GetConfigValue(string key);

    /// <summary>
    ///     This method gets a configuration value as a string.
    /// </summary>
    /// <param name="key">The key of the configuration value to get.</param>
    /// <returns>The configuration value or <c>null</c> if the configuration value does not exist.</returns>
    string? GetConfigValueString(string key);

    /// <summary>
    ///     This method sets a configuration value.
    /// </summary>
    /// <typeparam name="T">The type of the configuration value to set.</typeparam>
    /// <param name="key">The key of the configuration value to set.</param>
    /// <param name="value">The value to set the configuration value to.</param>
    void SetConfigValue<T>(string key, T value);

    /// <summary>
    ///     This method gets a list of all uploads.
    /// </summary>
    /// <returns>A list of all uploads.</returns>
    /// <remarks>This method queries the database and can be slow. So it should not be called often.</remarks>
    Task<IReadOnlyList<IUploadedItem>> GetUploads();

    /// <summary>
    ///     This method creates a new upload stream.
    /// </summary>
    /// <param name="extension">The extension of the file to upload.</param>
    /// <param name="name">The name of the file to upload.</param>
    /// <returns>The id of the upload stream.</returns>
    Task<string> CreateUploadStream(string extension, string? name = null);

    /// <summary>
    ///     This method terminates an upload stream.
    /// </summary>
    /// <param name="streamId">The id of the upload stream to terminate.</param>
    /// <returns></returns>
    Task TerminateUploadStream(string streamId);

    /// <summary>
    ///     This method uploads a chunk to an upload stream with a <see cref="Stream" /> as the request body.
    /// </summary>
    /// <param name="streamId">The id of the upload stream to upload the chunk to.</param>
    /// <param name="requestBody">The request body to upload.</param>
    /// <param name="hash">The hash of the chunk.</param>
    /// <returns><c>true</c> if the chunk was uploaded successfully, <c>false</c> otherwise.</returns>
    Task<bool> UploadChunk(string streamId, Stream requestBody, string? hash = null);

    /// <summary>
    ///     This method uploads a chunk to an upload stream with a <see cref="byte" /> array as the request body.
    /// </summary>
    /// <param name="streamId">The id of the upload stream to upload the chunk to.</param>
    /// <param name="requestBody">The request body to upload.</param>
    /// <param name="hash">The hash of the chunk.</param>
    /// <returns><c>true</c> if the chunk was uploaded successfully, <c>false</c> otherwise.</returns>
    Task<bool> UploadChunk(string streamId, byte[] requestBody, string? hash = null);

    /// <summary>
    ///     This method uploads a chunk to an upload stream with a <see cref="string" /> as the request body.
    /// </summary>
    /// <param name="streamId">The id of the upload stream to upload the chunk to.</param>
    /// <param name="requestBody">The request body to upload.</param>
    /// <param name="hash">The hash of the chunk.</param>
    /// <remarks>
    ///     The server converts the <paramref name="requestBody" /> to a <see cref="byte" /> array using
    ///     <see cref="System.Text.Encoding.UTF8" />.
    /// </remarks>
    Task<bool> UploadChunk(string streamId, string requestBody, string? hash = null);

    /// <summary>
    ///     This method uploads a chunk to an upload stream with a <see cref="string" /> as the request body using the
    ///     specified encoding.
    /// </summary>
    /// <param name="streamId">The id of the upload stream to upload the chunk to.</param>
    /// <param name="requestBody">The request body to upload.</param>
    /// <param name="encoding">
    ///     The encoding to use to convert the <paramref name="requestBody" /> to a <see cref="byte" />
    ///     array.
    /// </param>
    /// <param name="hash">The hash of the chunk.</param>
    /// <remarks>
    ///     The server converts the <paramref name="requestBody" /> to a <see cref="byte" /> array using the specified
    ///     <paramref name="encoding" />.
    /// </remarks>
    Task<bool> UploadChunk(string streamId, string requestBody, Encoding encoding, string? hash = null);

    /// <summary>
    ///     This method finalizes an upload stream.
    /// </summary>
    /// <param name="streamId">The id of the upload stream to finalize.</param>
    /// <param name="hash">The hash of the file.</param>
    /// <returns>The id of the uploaded file or <c>null</c> if the upload failed.</returns>
    Task<string?> FinalizeUpload(string streamId, string? hash = null);

    /// <summary>
    ///     This method checks whether an upload stream exists.
    /// </summary>
    /// <param name="streamId">The id of the upload stream to check.</param>
    /// <returns><c>true</c> if the upload stream exists, <c>false</c> otherwise.</returns>
    bool DoesUploadStreamExist(string streamId);

    /// <summary>
    ///     Gets the <see cref="IUploadItem" /> object representing the upload stream with the specified id.
    /// </summary>
    /// <param name="streamId">The id of the upload stream to get.</param>
    /// <returns>The upload stream with the specified id or <c>null</c> if no upload stream with the specified id exists.</returns>
    Task<IUploadItem?> GetUploadItem(string streamId);

    /// <summary>
    ///     This method gets the <see cref="IUploadedItem" /> object representing the uploaded file with the specified id.
    /// </summary>
    /// <param name="uploadId">The id of the uploaded file to get.</param>
    /// <returns>The uploaded file with the specified id or <c>null</c> if no uploaded file with the specified id exists.</returns>
    Task<IUploadedItem?> GetUploadedItem(string uploadId);

    /// <summary>
    ///     This method gets the mime type for the specified extension.
    /// </summary>
    /// <param name="extension">The extension to get the mime type for.</param>
    /// <returns>An enumeration of mime types for the specified extension.</returns>
    Task<IEnumerable<string>> GetMimeType(string extension);

    /// <summary>
    ///     Gets the stream of an uploaded file.
    /// </summary>
    /// <param name="uploadId">The id of the uploaded file to get the stream for.</param>
    /// <returns>The stream for the uploaded file or <c>null</c> if no uploaded file with the specified id exists.</returns>
    Task<Stream?> GetUploadedFileStream(string uploadId);

    /// <summary>
    ///     Gets the bytes of an uploaded file.
    /// </summary>
    /// <param name="uploadId">The id of the uploaded file to get the bytes for.</param>
    /// <returns>The bytes for the uploaded file or <c>null</c> if no uploaded file with the specified id exists.</returns>
    /// <remarks>
    ///     This method should only be used for small files, as it loads the whole file into memory. For large files, use
    ///     <see cref="GetUploadedFileStream" /> instead.
    /// </remarks>
    Task<byte[]?> GetUploadedFileBytes(string uploadId);

    /// <summary>
    ///     Gets the string of an uploaded file.
    /// </summary>
    /// <param name="uploadId">The id of the uploaded file to get the string for.</param>
    /// <returns>The string for the uploaded file or <c>null</c> if no uploaded file with the specified id exists.</returns>
    /// <remarks>
    ///     This method should only be used for small files, as it loads the whole file into memory. For large files, use
    ///     <see cref="GetUploadedFileStream" /> instead. And the server converts the bytes to a string using
    ///     <see cref="System.Text.Encoding.UTF8" />.
    /// </remarks>
    Task<string?> GetUploadedFileString(string uploadId);

    /// <summary>
    ///     Gets the string of an uploaded file using the specified encoding.
    /// </summary>
    /// <param name="uploadId">The id of the uploaded file to get the string for.</param>
    /// <param name="encoding">The encoding to use to convert the bytes to a string.</param>
    /// <returns>The string for the uploaded file or <c>null</c> if no uploaded file with the specified id exists.</returns>
    /// <remarks>
    ///     This method should only be used for small files, as it loads the whole file into memory. For large files, use
    ///     <see cref="GetUploadedFileStream" /> instead. And the server converts the bytes to a string using the specified
    ///     <paramref name="encoding" />.
    /// </remarks>
    Task<string?> GetUploadedFileString(string uploadId, Encoding encoding);

    /// <summary>
    ///     This method initiates the server shutdown.
    /// </summary>
    /// <param name="plugin">The plugin initiating the shutdown.</param>
    /// <param name="reason">The reason for the shutdown.</param>
    /// <param name="delay">The delay before the shutdown is initiated.</param>
    void Shutdown(IPlugin plugin, string reason = "Plugin initiated shutdown", TimeSpan delay = default);

    /// <summary>
    ///     This event is fired when a new upload stream is created.
    /// </summary>
    event EventHandler<UploadStreamCreatedEventArgs>? UploadStreamCreated;

    /// <summary>
    ///     This event is fired when a chunk is uploaded to an upload stream.
    /// </summary>
    /// <remarks>This event is fired before the chunk is processed. Be careful as it is fired often.</remarks>
    event EventHandler<ChunkUploadedEventArgs>? ChunkUploaded;

    /// <summary>
    ///     This event is fired when an upload stream is finalized/a file was fully uploaded.
    /// </summary>
    /// <remarks>This event is fired after the upload stream is finalized.</remarks>
    event EventHandler<UploadStreamFinalizedEventArgs>? UploadStreamFinalized;

    /// <summary>
    ///     This event is fired when a line of text is logged to the console.
    /// </summary>
    event EventHandler<ConsoleLineWrittenEventArgs>? ConsoleLineWritten;
}