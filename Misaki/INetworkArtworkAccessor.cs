namespace Misaki;

public interface INetworkArtworkAccessor : IMisakiService
{
    Task<bool> PostFavoriteAsync(string id, bool favorite);

    Task<IArtworkInfo> GetArtworkAsync(string id, bool favorite);
}
