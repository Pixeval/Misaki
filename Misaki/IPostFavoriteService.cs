using System.Threading;
using System.Threading.Tasks;

namespace Misaki;

public interface IPostFavoriteService : IMisakiService
{
    Task<bool> PostFavoriteAsync(string id, bool favorite, CancellationToken token = default);
}
