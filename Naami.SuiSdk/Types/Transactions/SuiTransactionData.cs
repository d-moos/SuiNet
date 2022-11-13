using Naami.SuiSdk.Types.Custom;

namespace Naami.SuiSdk.Types.Transactions;

public record SuiTransactionData(
    SuiTransactionKind[] Transactions,
    SuiAddress Sender,
    SuiObjectRef GasPayment,
    ulong GasBudget
);