namespace Misaki;

/// <remarks>
/// <see cref="ImageType.SingleImage"/>
/// </remarks>
public interface ISingleImage : IImageFrame, IArtworkInfo
{
    public int SetIndex { get; }
}
