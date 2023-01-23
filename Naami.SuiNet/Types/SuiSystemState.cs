using Naami.SuiNet.SuiTypes;
using Naami.SuiNet.Types.Delegation;
using Naami.SuiNet.Types.Numerics;
using Naami.SuiNet.Types.Structures;

namespace Naami.SuiNet.Types;

public record SuiSystemState(
    Uid Info,
    U64 Epoch,
    ValidatorSet Validators,
    Supply TreasuryCap,
    SuiTypes.Balance StorageFund,
    SystemParameters Parameters,
    U64 ReferenceGasPrice,
    VecMap<SuiAddress, VecSet<SuiAddress>> ValidatorReportRecords,
    StakeSubsidy StakeSubsidy,
    bool SafeMode
);