using Naami.SuiSdk.Types.Custom;
using Naami.SuiSdk.Types.Transactions;

namespace Naami.SuiSdk.Types;

public record SuiCertifiedTransactionEffects(TransactionEffectsDigest TransactionEffectsDigest,
    SuiTransactionEffects Effects, AuthorityStrongQuorumSignInfo AuthSignInfo);