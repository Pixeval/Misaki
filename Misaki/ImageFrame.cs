namespace Misaki;

public record ImageFrame(int Width, int Height) : IImageFrame
{
    public ulong ByteSize { get; init; }

    public required Uri ImageUri { get; init; }

    public ImageFrame(IImageSize frame, int wh, bool isWidth)
        :this (isWidth ? wh : (int) ((double) wh * frame.Width) / frame.Height,
            isWidth ? (int) ((double) wh * frame.Height) / frame.Width : wh)
    {
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class FixTypeAttribute(FixType fixType) : Attribute
    {
        public FixType FixType { get; } = fixType;
    }
    
    [AttributeUsage(AttributeTargets.Field)]
    public class SizeAttribute(int width, int height) : Attribute
    {
        public int Width { get; } = width;

        public int Height { get; } = height;
    }

    public enum FixType
    {
        FixWidth,
        FixHeight,
        FixAll
    }
}