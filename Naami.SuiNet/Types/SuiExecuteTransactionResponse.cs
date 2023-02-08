using Naami.SuiNet.Types.Transactions;

namespace Naami.SuiNet.Types;

public record SuiExecuteTransactionResponse(
    SuiCertifiedTransaction Certificate,
    SuiCertifiedTransactionEffects Effects, /* name? */
    bool ConfirmedLocalExecution
);