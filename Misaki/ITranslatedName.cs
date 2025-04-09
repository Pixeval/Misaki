namespace Misaki;

public interface ITranslatedName : IMisakiModel
{
    string Name { get; }

    string TranslatedName { get; }
}
