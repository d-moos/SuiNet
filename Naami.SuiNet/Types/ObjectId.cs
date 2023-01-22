using System.Diagnostics.CodeAnalysis;
using Naami.SuiNet.Types.Numerics;

namespace Naami.SuiNet.Types;

public readonly struct ObjectId
{
    private readonly string _objectId;

    public ObjectId(string objectId)
    {
        _objectId = objectId;
    }

    public override string ToString() => _objectId;

    public static implicit operator ObjectId(string objectId) => new(objectId);
    public static implicit operator string(ObjectId objectId) => objectId._objectId;
}

public readonly struct StakeUnit
{
    private readonly U64 _value;

    public StakeUnit(string value)
    {
        _value = value;
    }

    public override string ToString() => _value;

    public static implicit operator StakeUnit(U64 stakeUnit) => new(stakeUnit);
    public static implicit operator U64(StakeUnit stakeUnit) => stakeUnit._value;
}