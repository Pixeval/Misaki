namespace Misaki;

/// <remarks>
/// <see cref="ImageType.SingleAnimatedImage"/>
/// </remarks>
public interface ISingleAnimatedImage : IAnimatedImageFrame, IArtworkInfo
{
    IPreloadableList<IAnimatedImageFrame> AnimatedThumbnails { get; }
}

[Flags]
public enum SingleAnimatedImageType
{
    None = 0,
    SingleFile = 1,
    MultiFiles = 2,
    Both = SingleFile | MultiFiles
}

public interface IAnimatedImageFrame : IImageSize
{
    SingleAnimatedImageType PreferredAnimatedImageType { get; }

    /// <summary>
    /// Used when <see cref="PreferredAnimatedImageType"/> has <see cref="SingleAnimatedImageType.SingleFile"/>
    /// </summary>
    Uri? SingleImageUri { get; }

    /// <summary>
    /// Used when <see cref="PreferredAnimatedImageType"/> has <see cref="SingleAnimatedImageType.MultiFiles"/>
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

    public AnimatedImageFrame(IPreloadableList<(Uri Uri, int MsDelay)> multiImageUris)
    {
        MultiImageUris = multiImageUris;
        PreferredAnimatedImageType = SingleAnimatedImageType.MultiFiles;
    }

    public AnimatedImageFrame(Uri singleImageUri, IPreloadableList<(Uri Uri, int MsDelay)> multiImageUris)
    {
        SingleImageUri = singleImageUri;
        MultiImageUris = multiImageUris;
        PreferredAnimatedImageType = SingleAnimatedImageType.Both;
    }

    public SingleAnimatedImageType PreferredAnimatedImageType { get; }

    public Uri? SingleImageUri { get; }

    public IPreloadableList<(Uri Uri, int MsDelay)>? MultiImageUris { get; }

    public int Width { get; init; }

    public int Height { get; init; }
}
