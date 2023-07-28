namespace KekUploadServerApi.Uploads;

public class UploadStreamCreatedEventArgs : EventArgs
{
    public UploadStreamCreatedEventArgs(IUploadItem uploadStream)
    {
        UploadStream = uploadStream;
    }
    
    /// <summary>
    /// The upload stream that was created.
    /// </summary>
    public IUploadItem UploadStream { get; }
}