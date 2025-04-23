namespace Misaki;

/// <remarks>
/// <see cref="ImageType.ImageSet"/>
/// </remarks>
public interface IImageSet : IArtworkInfo
{
    IPreloadableList<ISingleImage> Pages { get; }
    
    int PageCount { get; }
}
