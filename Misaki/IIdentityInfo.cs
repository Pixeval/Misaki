namespace Misaki;

public interface IIdentityInfo : IMisakiModel
{
    string Platform { get; }

    string Id { get; }

    const string Pixiv = "pixiv";

    const string Danbooru = "danbooru";

    const string Yandere = "yandere";

    const string Sankaku = "sankaku";

    const string Gelbooru = "gelbooru";

    const string Rule34 = "rule34";
}
