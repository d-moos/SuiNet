using Naami.SuiNet.Types;
using Naami.SuiNet.Types.Numerics;

namespace Naami.SuiNet.Apis.Governance;

public record StakeSubsidy(U64 EpochCounter, SuiTypes.Balance Balance, U64 CurrentEpochAmount);