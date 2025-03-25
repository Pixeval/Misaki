namespace Misaki;

public interface IImageFrame : IImageSize
{
    ulong ByteSize { get; }

    Uri ImageUri { get; }
}