using Naami.SuiNet.Types.Numerics;

namespace Naami.SuiNet.Apis.Governance;

public record ValidatorSet(
    U64 ValidatorStake,
    U64 DelegationStake,
    Validator[] ActiveValidators,
    Validator[] PendingValidators,
    U64[] PendingRemovals,
    ValidatorMetadata[] NextEpochValidators,
    VecMap<ValidatorPair, TableVec> PendingDelegationSwitches
);