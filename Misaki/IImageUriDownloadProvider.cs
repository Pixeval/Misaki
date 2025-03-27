namespace Misaki;

public interface IImageUriDownloadProvider : IMisakiService
{
    string Schema { get; }

    Task<Stream> DownloadImageAsync(ISingleImage image, Stream? destination = null);

    Task<IReadOnlyList<Stream>> DownloadAnimatedImagePreferredSeparatedAsync(ISingleImage image);
}
