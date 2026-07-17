using System;

namespace Misaki;

public interface ISerializable : IMisakiModel
{
    string Serialize();

    static ISerializable Deserialize(string data) => throw new NotSupportedException();

    string SerializeKey { get; }
}
