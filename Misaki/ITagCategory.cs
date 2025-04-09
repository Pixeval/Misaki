namespace Misaki;

public interface ITagCategory : ITranslatedName
{
    static ITagCategory Empty { get; } = new EmptyCategory();

    string Description { get; }

    private readonly record struct EmptyCategory : ITagCategory
    {
        public string Name => "";

        public string TranslatedName => "";

        public string Description => "";
    }
}
