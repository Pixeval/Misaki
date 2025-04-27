namespace Misaki;

public interface IIdentityInfo : IPlatformInfo, IMisakiModel
{
    string Id { get; }
}
