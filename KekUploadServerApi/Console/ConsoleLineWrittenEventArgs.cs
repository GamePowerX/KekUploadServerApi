namespace KekUploadServerApi.Console;

public class ConsoleLineWrittenEventArgs : EventArgs
{
    public ConsoleLineWrittenEventArgs(string line)
    {
        Line = line;
    }

    /// <summary>
    ///     The line that was written to the console.
    /// </summary>
    public string Line { get; }
}