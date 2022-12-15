using Naami.SuiNet.Types.Custom;

namespace Naami.SuiNet.Types.Transactions;

public record SuiTransactionData(
    SuiTransactionKind[] Transactions,
    SuiAddress Sender,
    SuiObjectRef GasPayment,
    ulong GasBudget
);