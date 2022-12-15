using Naami.SuiNet.Types.Transactions;

namespace Naami.SuiNet.Types;

public record EffectsCert(SuiCertifiedTransaction Certificate, SuiCertifiedTransactionEffects Effects, /* name? */
    bool ConfirmedLocalExecution);