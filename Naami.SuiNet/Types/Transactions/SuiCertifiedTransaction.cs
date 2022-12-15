using Naami.SuiNet.Types.Custom;

namespace Naami.SuiNet.Types.Transactions;

public record SuiCertifiedTransaction(
    TransactionDigest TransactionDigest,
    SuiTransactionData Data,
    Signature Signature,
    AuthorityStrongQuorumSignInfo AuthSignInfo
);