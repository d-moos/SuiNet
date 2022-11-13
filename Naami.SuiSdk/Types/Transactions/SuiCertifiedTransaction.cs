using Naami.SuiSdk.Types.Custom;

namespace Naami.SuiSdk.Types.Transactions;

public record SuiCertifiedTransaction(
    TransactionDigest TransactionDigest,
    SuiTransactionData Data,
    Signature Signature,
    AuthorityStrongQuorumSignInfo AuthSignInfo
);