namespace Misaki;

public class AnimatedImageFrame : IAnimatedImageFrame
{
    public AnimatedImageFrame(Uri singleImageUri)
    {
        SingleImageUri = singleImageUri;
        PreferredAnimatedImageType = SingleAnimatedImageType.SingleFile;
    }
    
    public AnimatedImageFrame(Uri singleImageUri, IPreloadableList<int> msDelay)
    {
        SingleImageUri = singleImageUri;
        ZipImageDelays = msDelay;
        PreferredAnimatedImageType = SingleAnimatedImageType.SingleZipFile;
    }
    
    public AnimatedImageFrame(IPreloadableList<(Uri Uri, int MsDelay)> multiImageUris)
    {
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
