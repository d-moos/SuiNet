using Naami.SuiNet.Types.Numerics;

namespace Naami.SuiNet.Types;

public readonly struct EpochId
{
    private readonly U64 _epochId;

    public EpochId(U64 epochId)
    {
        _epochId = epochId;
    }

    public static implicit operator EpochId(U64 epochId) => new(epochId);
    public static implicit operator U64(EpochId epochId) => epochId._epochId;
}