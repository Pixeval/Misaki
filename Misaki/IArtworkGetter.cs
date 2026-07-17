using System.Threading;
using System.Threading.Tasks;

namespace Misaki;

public interface IGetArtworkService : IMisakiService
{
    Task<IArtworkInfo> GetArtworkAsync(string id, CancellationToken token = default);
}
