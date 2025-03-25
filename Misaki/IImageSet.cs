namespace Misaki;

/// <remarks>
/// <see cref="ImageType.ImageSet"/>
/// </remarks>
public interface IImageSet : IArtworkInfo
{
    IPreloadableEnumerable<IArtworkInfo> Pages { get; }
    
    int PageCount { get; }
}
