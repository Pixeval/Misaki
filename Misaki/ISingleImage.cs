namespace Misaki;

/// <remarks>
/// <see cref="ImageType.SingleImage"/>
/// </remarks>
public interface ISingleImage : IImageFrame, IArtworkInfo
{
    /// <summary>
    /// Use -1 if not in a set
    /// </summary>
    public int SetIndex { get; }
}
