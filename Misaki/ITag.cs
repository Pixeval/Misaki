namespace Misaki;

public interface ITag : IMisakiModel
{
    ITagCategory Category { get; }

    string Name { get; }

    string Description { get; }
}