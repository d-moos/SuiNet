using Naami.SuiNet.Types;
using Naami.SuiNet.Types.Numerics;

namespace Naami.SuiNet.Apis.Governance;

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