using Naami.SuiNet.Types.Numerics;

namespace Naami.SuiNet.Apis.Governance;

public record Validator(
    ValidatorMetadata Metadata,
    U64 VotingPower,
    U64 StakeAmount,
    U64 PendingStake,
    U64 PendingWithdraw,
    U64 GasPrice,
    StakingPool DelegationStakingPool,
    U64 CommissionRate
);