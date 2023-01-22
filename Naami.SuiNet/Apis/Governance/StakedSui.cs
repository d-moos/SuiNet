using Naami.SuiNet.Types;
using Naami.SuiNet.Types.Numerics;

namespace Naami.SuiNet.Apis.Governance;

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