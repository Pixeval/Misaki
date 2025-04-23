namespace Misaki;

public interface IImageUriDownloadProvider : IMisakiService, IPlatformInfo
{
    Func<Stream>? StreamProvider { get; set; }

    Task<Stream> DownloadSingleImageAsync(ISingleImage image, IImageFrame frame, IProgress<double>? progress = null, Stream? destination = null, CancellationToken token = default);

    Task<IReadOnlyList<(Stream Image, int MsDelay)>> DownloadAnimatedImagePreferredSeparatedAsync(ISingleAnimatedImage image, IAnimatedImageFrame frame, IProgress<double>? progress = null, CancellationToken token = default);
}
