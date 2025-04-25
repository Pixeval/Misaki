namespace Misaki;

/// <remarks>
/// <see cref="ImageType.SingleAnimatedImage"/>
/// </remarks>
public interface ISingleAnimatedImage : IAnimatedImageFrame, IArtworkInfo
{
    IPreloadableList<IAnimatedImageFrame> AnimatedThumbnails { get; }
}
