namespace Misaki;

public interface IImageSize : IMisakaModel
{
    int Width { get; }

    int Height { get; }
}