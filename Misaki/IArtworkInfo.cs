namespace Misaki;

public interface IArtworkInfo : IIdentityInfo
{
    string Title { get; }

    string Description { get; }

    Uri WebsiteUri { get; }

    DateTimeOffset CreateDate { get; }

    DateTimeOffset UpdateDate { get; }

    DateTimeOffset ModifyDate { get; }

    IPreloadableEnumerable<IUser> Authors { get; }

    IPreloadableEnumerable<IUser> Uploaders { get; }

    SafeRating SafeRating { get; }

    ILookup<ITagCategory, ITag> Tags { get; }

    IReadOnlyList<IImageFrame> Thumbnails { get; }

    IReadOnlyDictionary<string, object> AdditionalInfo { get; }

    ImageType ImageType { get; }

    int TotalFavorite { get; }

    int TotalView { get; }

    bool IsFavorite { get; }
}
