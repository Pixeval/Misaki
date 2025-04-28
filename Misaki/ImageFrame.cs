namespace Misaki;

public record ImageFrame() : IImageFrame
{
    public int Width { get; init; } = -1;

    public int Height { get; init; } = -1;

    public ulong ByteSize { get; init; }

    public required Uri ImageUri { get; init; }

    public ImageFrame(IImageSize size) : this()
    {
        Width = size.Width;
        Height = size.Height;
    }
    
    [AttributeUsage(AttributeTargets.Field)]
    public class SizeAttribute(int width, int height) : Attribute
    {
        public int Width { get; } = width;

        public int Height { get; } = height;
    }
}
