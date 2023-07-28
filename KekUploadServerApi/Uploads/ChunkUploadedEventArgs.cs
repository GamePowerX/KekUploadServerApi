namespace KekUploadServerApi.Uploads;

public class ChunkUploadedEventArgs : EventArgs
{
    public ChunkUploadedEventArgs(IUploadItem uploadStream, Stream chunk)
    {
        UploadStream = uploadStream;
        Chunk = chunk;
    }
    
    /// <summary>
    /// The upload stream that the chunk was uploaded to. This event is fired before the chunk is written to the stream.
    /// </summary>
    public IUploadItem UploadStream { get; }
    /// <summary>
    /// A stream representing the chunk that was uploaded. This stream is read-only.
    /// </summary>
    public Stream Chunk { get; }
}