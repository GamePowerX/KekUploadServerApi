namespace KekUploadServerApi;

/// <summary>
/// The interface for plugins to implement.
/// </summary>
public interface IPlugin
{
    /// <summary>
    /// This method is called when the plugin is loaded.
    /// It is used to pass the server instance to the plugin.
    /// And also to initialize the plugin. (e.g. load config, register events, etc.)
    /// </summary>
    /// <remarks>Never call this method yourself, it is called by the server.</remarks>
    /// <param name="server"></param>
    /// <returns></returns>
    Task Load(IKekUploadServer server);
    /// <summary>
    /// This method is called when the plugin is started.
    /// </summary>
    /// <remarks>Never call this method yourself,as it is called by the server.</remarks>
    /// <returns></returns>
    Task Start();
    /// <summary>
    /// This method is called when the plugin is unloaded.
    /// When this method is called, the plugin should stop all tasks and free all resources.
    /// </summary>
    /// <remarks>Never call this method yourself, as it is called by the server.</remarks>
    /// <returns></returns>
    Task Unload();
    /// <summary>
    /// The information about the plugin.
    /// This is used by the server to identify the plugin.
    /// It is also used by the server to check for dependencies.
    /// </summary>
    /// <remarks>This property must be properly implemented by the plugin else the plugin will not be loaded.</remarks>
    PluginInfo Info { get; }
}