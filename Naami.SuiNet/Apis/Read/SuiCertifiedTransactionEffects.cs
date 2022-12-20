using Naami.SuiNet.Apis.Read.Transactions;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Read;

public record SuiCertifiedTransactionEffects(TransactionEffectsDigest TransactionEffectsDigest,
    SuiTransactionEffects Effects, AuthorityStrongQuorumSignInfo AuthSignInfo);