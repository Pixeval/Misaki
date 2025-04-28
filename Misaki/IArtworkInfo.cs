namespace Misaki;

public interface IArtworkInfo : IImageSize, IIdentityInfo
{
    string Title { get; }

    string Description { get; }

    Uri WebsiteUri { get; }

    Uri AppUri { get; }

    DateTimeOffset CreateDate { get; }

    IPreloadableList<IUser> Authors { get; }

    IPreloadableList<IUser> Uploaders { get; }

    SafeRating SafeRating { get; }

    ILookup<ITagCategory, ITag> Tags { get; }

    IReadOnlyCollection<IImageFrame> Thumbnails { get; }

    IReadOnlyDictionary<string, object> AdditionalInfo { get; }

    ImageType ImageType { get; }

    int TotalFavorite { get; }

    int TotalView { get; }

    bool IsFavorite { get; }

    bool IsAiGenerated { get; }
}
