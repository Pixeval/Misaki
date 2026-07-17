using System.Net.Http;

namespace Misaki;

public interface IDownloadHttpClientService : IMisakiService
{
    HttpClient GetApiClient();

    HttpClient GetImageDownloadClient();
}
