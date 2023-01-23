using Naami.SuiNet.Types.Delegation;
using Naami.SuiNet.Types.Numerics;

namespace Naami.SuiNet.Types;

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