namespace Misaki;

public interface INetworkArtworkAccessor : IMisakaModel
{
    Task<bool> PostFavoriteAsync(bool favorite);
}
