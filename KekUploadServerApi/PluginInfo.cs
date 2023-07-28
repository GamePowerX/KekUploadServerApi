namespace KekUploadServerApi;

/// <summary>
/// This class contains information about a plugin.
/// </summary>
public class PluginInfo
{
    /// <summary>
    /// The name of the plugin. Should be unique and match the C# naming conventions for classes.
    /// </summary>
    /// <example>MyPlugin</example>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// The author of the plugin.
    /// </summary>
    /// <example>John Doe</example>
    public string Author { get; set; } = string.Empty;
    /// <summary>
    /// The description of the plugin.
    /// </summary>
    /// <example>A plugin that does something.</example>
    public string Description { get; set; } = string.Empty;
    /// <summary>
    /// The version of the plugin. Should follow the semantic versioning scheme.
    /// </summary>
    /// <example>1.0.0</example>
    public string Version { get; set; } = string.Empty;
    /// <summary>
    /// The dependencies of the plugin. Should be the names of the plugins that this plugin depends on.
    /// </summary>
    /// <remarks>The plugin names are case-sensitive and should be the same as the <see cref="Name"/> property of the plugins <see cref="PluginInfo"/> class. If no dependencies are required, set this property to <see cref="Array.Empty{T}"/>.</remarks>
    /// <example>new []{"MyOtherPlugin"} or Array.Empty&lt;string&gt;()</example>
    public string[] Dependencies { get; set; } = Array.Empty<string>();
    /// <summary>
    /// The optional dependencies of the plugin. Should be the names of the plugins that this plugin optionally depends on.
    /// </summary>
    /// <remarks>The plugin names are case-sensitive and should be the same as the <see cref="Name"/> property of the plugins <see cref="PluginInfo"/> class. If no optional dependencies are needed, set this property to <see cref="Array.Empty{T}"/>.</remarks>
    /// <example>new []{"MyOtherPlugin"} or Array.Empty&lt;string&gt;()</example>
    public string[] OptionalDependencies { get; set; } = Array.Empty<string>();
    /// <summary>
    /// The plugins that should be loaded before this plugin.
    /// </summary>
    /// <remarks>The plugin names are case-sensitive and should be the same as the <see cref="Name"/> property of the plugins <see cref="PluginInfo"/> class. If no plugins should be loaded before this plugin, set this property to <see cref="Array.Empty{T}"/>.</remarks>
    /// <example>new []{"MyOtherPluginThatLoadsBefore"} or Array.Empty&lt;string&gt;()</example>
    public string[] LoadBefore { get; set; } = Array.Empty<string>();
    /// <summary>
    /// The plugins that should be loaded after this plugin.
    /// </summary>
    /// <remarks>The plugin names are case-sensitive and should be the same as the <see cref="Name"/> property of the plugins <see cref="PluginInfo"/> class. If no plugins should be loaded after this plugin, set this property to <see cref="Array.Empty{T}"/>.</remarks>
    /// <example>new []{"MyOtherPluginThatLoadsAfter"} or Array.Empty&lt;string&gt;()</example>
    public string[] LoadAfter { get; set; } = Array.Empty<string>();
}