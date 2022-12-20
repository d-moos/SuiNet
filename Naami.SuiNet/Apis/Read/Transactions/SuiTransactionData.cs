using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Read.Transactions;

public record SuiTransactionData(
    SuiTransactionKind[] Transactions,
    SuiAddress Sender,
    SuiObjectRef GasPayment,
    ulong GasBudget
);