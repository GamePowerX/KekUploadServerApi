namespace KekUploadServerApi.Uploads;

public class UploadStreamFinalizedEventArgs : EventArgs
{
    public UploadStreamFinalizedEventArgs(IUploadItem uploadItem, IUploadedItem uploadedItem)
    {
        UploadItem = uploadItem;
        UploadedItem = uploadedItem;
    }

    /// <summary>
    ///     The upload stream that was finalized.
    /// </summary>
    public IUploadItem UploadItem { get; }

    /// <summary>
    ///     The uploaded item that was created as a result of finalizing the upload stream.
    /// </summary>
    public IUploadedItem UploadedItem { get; }
}