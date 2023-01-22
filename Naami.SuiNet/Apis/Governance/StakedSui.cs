using Naami.SuiNet.Types;
using Naami.SuiNet.Types.Numerics;

namespace Naami.SuiNet.Apis.Governance;

public record StakedSui(
    Uid Id,
    SuiAddress ValidatorAddress,
    U64 PoolStatingEpoch,
    U64 DelegationRequestEpoch,
    Balance Principal
)
{
    public EpochId? SuiTokenLock { get; init; }
}