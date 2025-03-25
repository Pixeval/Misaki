namespace Misaki;

public interface ITag : IMisakaModel
{
    ITagCategory Category { get; }

    string Name { get; }

    string Description { get; }
}