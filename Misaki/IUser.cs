namespace Misaki;

public interface IUser : IIdentityInfo
{
    string Name { get; }

    string Description { get; }

    Uri WebsiteUri { get; }

    IReadOnlyList<IImageFrame> Avatar { get; }

    IReadOnlyDictionary<string, Uri> ContactInformation { get; }

    IReadOnlyDictionary<string, object> AdditionalInfo { get; }
}