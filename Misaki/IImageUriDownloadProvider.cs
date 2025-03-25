namespace Misaki;

public interface IImageUriDownloadProvider : IMisakaService
{
    string Schema { get; }

    Task<Stream> DownloadImageAsync(ISingleImage image, Stream? destination = null);

    Task<IReadOnlyList<Stream>> DownloadAnimatedImagePreferredSeparatedAsync(ISingleImage image);
}
