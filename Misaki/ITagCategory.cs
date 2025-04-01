namespace Misaki;

public interface ITagCategory : IMisakiModel
{
    static ITagCategory Empty { get; } = new EmptyCategory();

    string Name { get; }

    string TranslatedName { get; }

    string Description { get; }

    private readonly record struct EmptyCategory : ITagCategory
    {
        public string Name => "";

        public string TranslatedName => "";

        public string Description => "";
    }
}
