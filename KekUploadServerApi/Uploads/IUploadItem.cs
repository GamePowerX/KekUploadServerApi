namespace KekUploadServerApi.Uploads;

public interface IUploadItem
{
    public string UploadStreamId { get; }
    public string Extension { get; }
    public string? Name { get; }
}