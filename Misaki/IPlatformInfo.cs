namespace Misaki;

public interface IPlatformInfo : IMisakiBase
{
    string Platform { get; }

    const string All = "all";

    const string Pixiv = "pixiv";

    const string Danbooru = "danbooru";

    const string Yandere = "yandere";

    const string Sankaku = "sankaku";

    const string Gelbooru = "gelbooru";

    const string Rule34 = "rule34";
}
