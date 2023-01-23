using Naami.SuiNet.Types.Numerics;

namespace Naami.SuiNet.Types.Delegation;

public record StakeSubsidy(U64 EpochCounter, SuiTypes.Balance Balance, U64 CurrentEpochAmount);