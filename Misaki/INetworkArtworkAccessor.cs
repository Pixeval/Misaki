namespace Misaki;

public interface INetworkArtworkAccessor : IMisakiModel
{
    Task<bool> PostFavoriteAsync(bool favorite);
}
