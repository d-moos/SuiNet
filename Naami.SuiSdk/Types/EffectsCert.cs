using Naami.SuiSdk.Types.Transactions;

namespace Naami.SuiSdk.Types;

public record EffectsCert(SuiCertifiedTransaction Certificate, SuiCertifiedTransactionEffects Effects, /* name? */
    bool ConfirmedLocalExecution);