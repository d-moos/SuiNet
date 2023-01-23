using Naami.SuiNet.Types.Numerics;

namespace Naami.SuiNet.Types;

public record SystemParameters(U64 MinValidatorStake, U64 MaxValidatorCandidateCount);