namespace Misaki;

public interface IGetArtworkService : IMisakiService
{
    Task<IArtworkInfo> GetArtworkAsync(string id);
}
