namespace Misaki;

public interface IUser : IIdentityInfo
{
    string Name { get; }

    string Description { get; }

    Uri WebsiteUri { get; }

    Uri? AppUri { get; }

    IReadOnlyCollection<IImageFrame> Avatar { get; }

    IReadOnlyDictionary<string, Uri> ContactInformation { get; }

    IReadOnlyDictionary<string, object> AdditionalInfo { get; }
}
