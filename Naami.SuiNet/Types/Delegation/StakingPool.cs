using Naami.SuiNet.Types.Numerics;
using Naami.SuiNet.Types.Structures;

namespace Naami.SuiNet.Types.Delegation;

public record StakingPool(
    SuiAddress ValidatorAddress,
    U64 StartingEpoch,
    U64 SuiBalance,
    Balance RewardsPool,
    Supply DelegationTokenSupply,
    LinkedTable<ObjectId> PendingDelegations,
    TableVec PendingWithdraws
);