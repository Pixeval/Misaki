namespace Misaki;

public interface ITag : ITranslatedName
{
    ITagCategory Category { get; }

    string Description { get; }
}
