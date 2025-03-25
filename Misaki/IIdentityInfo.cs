namespace Misaki;

public interface IIdentityInfo : IMisakaModel
{
    string Platform { get; }

    long Id { get; }

    const string Pixiv = "pixiv";
}