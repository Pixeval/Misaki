namespace Misaki;

/// <remarks>
/// <see cref="ImageType.SingleAnimatedImage"/>
/// </remarks>
public interface ISingleAnimatedImage : IAnimatedImageFrame, IArtworkInfo
{
    IPreloadableList<IAnimatedImageFrame> AnimatedThumbnails { get; }
}

public enum SingleAnimatedImageType
{
    SingleZipFile,
    SingleFile,
    MultiFiles
}

public interface IAnimatedImageFrame : IImageSize
{
    SingleAnimatedImageType PreferredAnimatedImageType { get; }

    /// <summary>
    /// Used when <see cref="PreferredAnimatedImageType"/> is <see cref="SingleAnimatedImageType.SingleFile"/> or <see cref="SingleAnimatedImageType.SingleZipFile"/>
    /// </summary>
    Uri? SingleImageUri { get; }

    /// <summary>
    /// Used when <see cref="PreferredAnimatedImageType"/> is <see cref="SingleAnimatedImageType.SingleZipFile"/>
    /// </summary>
    IPreloadableList<int>? ZipImageDelays { get; }

    /// <summary>
    /// Used when <see cref="PreferredAnimatedImageType"/> is <see cref="SingleAnimatedImageType.MultiFiles"/>
    /// </summary>
    IPreloadableList<(Uri Uri, int MsDelay)>? MultiImageUris { get; }
}

public class AnimatedImageFrame : IAnimatedImageFrame
{
    public AnimatedImageFrame(Uri singleImageUri)
    {
        SingleImageUri = singleImageUri;
        PreferredAnimatedImageType = SingleAnimatedImageType.SingleFile;
    }
    
    public AnimatedImageFrame(Uri singleImageUri, IPreloadableList<int> msDelay)
    {
        SingleImageUri = singleImageUri;
        ZipImageDelays = msDelay;
        PreferredAnimatedImageType = SingleAnimatedImageType.SingleZipFile;
    }
    
    public AnimatedImageFrame(IPreloadableList<(Uri Uri, int MsDelay)> multiImageUris)
    {
        MultiImageUris = multiImageUris;
        PreferredAnimatedImageType = SingleAnimatedImageType.MultiFiles;
    }

    public SingleAnimatedImageType PreferredAnimatedImageType { get; }

    public Uri? SingleImageUri { get; }

    public IPreloadableList<int>? ZipImageDelays { get; }

    public IPreloadableList<(Uri Uri, int MsDelay)>? MultiImageUris { get; }

    public int Width { get; init; }

    public int Height { get; init; }
}
