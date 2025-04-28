namespace Misaki;

public class AnimatedImageFrame : IAnimatedImageFrame
{
    public AnimatedImageFrame(IImageSize size, Uri singleImageUri)
    {
        Width = size.Width;
        Height = size.Height;
        SingleImageUri = singleImageUri;
        PreferredAnimatedImageType = SingleAnimatedImageType.SingleFile;
    }
    
    public AnimatedImageFrame(IImageSize size, Uri singleImageUri, IPreloadableList<int> msDelay)
    {
        Width = size.Width;
        Height = size.Height;
        SingleImageUri = singleImageUri;
        ZipImageDelays = msDelay;
        PreferredAnimatedImageType = SingleAnimatedImageType.SingleZipFile;
    }
    
    public AnimatedImageFrame(IImageSize size, IPreloadableList<(Uri Uri, int MsDelay)> multiImageUris)
    {
        Width = size.Width;
        Height = size.Height;
        MultiImageUris = multiImageUris;
        PreferredAnimatedImageType = SingleAnimatedImageType.MultiFiles;
    }

    public SingleAnimatedImageType PreferredAnimatedImageType { get; }

    public Uri? SingleImageUri { get; }

    public IPreloadableList<int>? ZipImageDelays { get; }

    public IPreloadableList<(Uri Uri, int MsDelay)>? MultiImageUris { get; }

    public int Width { get; init; }

    public int Height { get; init; }
}
