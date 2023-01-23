using Naami.SuiNet.SuiTypes;
using Naami.SuiNet.Types.Numerics;

namespace Naami.SuiNet.Types.Delegation;

public record StakedSui(
    Uid Id,
    SuiAddress ValidatorAddress,
    U64 PoolStartingEpoch,
    U64 DelegationRequestEpoch,
    SuiTypes.Balance Principal
)
{
    public EpochId? SuiTokenLock { get; init; }
}