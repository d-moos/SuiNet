namespace Naami.SuiNet.Types;

public readonly struct EpochId
{
    private readonly ulong _epochId;

    public EpochId(ulong epochId)
    {
        _epochId = epochId;
    }

    public static implicit operator EpochId(ulong epochId) => new(epochId);
    public static implicit operator ulong(EpochId epochId) => epochId._epochId;
}