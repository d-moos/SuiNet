using Naami.SuiNet.Types;
using Naami.SuiNet.Types.Numerics;

namespace Naami.SuiNet.Apis.Governance;

public record StakingPool(
    SuiAddress ValidatorAddress,
    U64 StartingEpoch,
    U64 SuiBalance,
    Balance RewardsPool,
    Supply DelegationTokenSupply,
    LinkedTable<ObjectId> PendingDelegations,
    TableVec PendingWithdraws
);