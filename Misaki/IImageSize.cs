namespace Misaki;

public interface IImageSize : IMisakiModel
{
    int Width { get; }

    int Height { get; }

    double AspectRatio => (double) Width / Height;

    public static IImageSize FixWidth(IImageSize size, int width)
    {
        if (size.Width < width)
            return size;
        var height = (int) ((double) width * size.Height) / size.Width;
        return new ImageSize(width, height);
    }

    public static IImageSize FixHeight(IImageSize size, int height)
    {
        if (size.Height < height)
            return size;
        var width = (int) ((double) height * size.Width) / size.Height;
        return new ImageSize(width, height);
    }

    public static IImageSize Uniform(IImageSize size, int width, int height)
    {
        return size.AspectRatio > (double) width / height
            ? FixWidth(size, width)
            : FixHeight(size, height);
    }

    public static IImageSize Uniform(IImageSize size, int wh)
    {
        return size.AspectRatio > 1
            ? FixWidth(size, wh)
            : FixHeight(size, wh);
    }

    public static IImageSize UniformToFill(IImageSize size, int width, int height)
    {
        return size.AspectRatio > (double) width / height
            ? FixHeight(size, height)
            : FixWidth(size, width);
    }

    public static IImageSize UniformToFill(IImageSize size, int wh)
    {
        return size.AspectRatio > 1
            ? FixHeight(size, wh)
            : FixWidth(size, wh);
    }
}
