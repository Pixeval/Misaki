namespace Misaki;

public interface IImageSize : IMisakiModel
{
    int Width { get; }

    int Height { get; }
}