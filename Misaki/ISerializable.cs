namespace Misaki;

public interface ISerializable : IMisakiModel
{
    string Serialize();

    static ISerializable Deserialize(string data) => ThrowHelper.NotSupported<ISerializable>();

    string SerializeKey { get; }
}
