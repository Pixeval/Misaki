namespace Misaki;

public interface IPostFavoriteService : IMisakiService
{
    Task<bool> PostFavoriteAsync(string id, bool favorite);
}
