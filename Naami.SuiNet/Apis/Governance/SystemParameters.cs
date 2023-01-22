using Naami.SuiNet.Types.Numerics;

namespace Naami.SuiNet.Apis.Governance;

public record SystemParameters(U64 MinValidatorStake, U64 MaxValidatorCandidateCount);