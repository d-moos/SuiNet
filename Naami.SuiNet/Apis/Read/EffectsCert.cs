using Naami.SuiNet.Apis.Read.Transactions;

namespace Naami.SuiNet.Apis.Read;

public record EffectsCert(SuiCertifiedTransaction Certificate, SuiCertifiedTransactionEffects Effects, /* name? */
    bool ConfirmedLocalExecution);