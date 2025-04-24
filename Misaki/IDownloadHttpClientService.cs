namespace Misaki;

public interface IDownloadHttpClientService : IMisakiService, IPlatformInfo
{
    HttpClient GetApiClient();

    HttpClient GetImageDownloadClient();
}
