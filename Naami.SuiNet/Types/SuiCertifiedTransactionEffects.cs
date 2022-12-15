using Naami.SuiNet.Types.Custom;
using Naami.SuiNet.Types.Transactions;

namespace Naami.SuiNet.Types;

public record SuiCertifiedTransactionEffects(TransactionEffectsDigest TransactionEffectsDigest,
    SuiTransactionEffects Effects, AuthorityStrongQuorumSignInfo AuthSignInfo);