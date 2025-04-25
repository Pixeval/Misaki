namespace Misaki;

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
