namespace KekUploadServerApi.Uploads;

public interface IUploadedItem
{
    public string Id { get; }
    public string Extension { get; }
    public string? Name { get; }
    public string Hash { get; }
}