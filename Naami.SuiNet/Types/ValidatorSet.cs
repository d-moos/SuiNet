using Naami.SuiNet.Types.Numerics;
using Naami.SuiNet.Types.Structures;

namespace Naami.SuiNet.Types;

public record ValidatorSet(
    U64 ValidatorStake,
    U64 DelegationStake,
    Validator[] ActiveValidators,
    Validator[] PendingValidators,
    U64[] PendingRemovals,
    ValidatorMetadata[] NextEpochValidators,
    VecMap<ValidatorPair, TableVec> PendingDelegationSwitches
);