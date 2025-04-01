namespace Misaki;

public interface ITag : IMisakiModel
{
    ITagCategory Category { get; }

    string Name { get; }

    string TranslatedName { get; }

    string Description { get; }
}
