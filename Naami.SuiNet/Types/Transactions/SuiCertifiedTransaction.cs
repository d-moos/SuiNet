namespace Naami.SuiNet.Types.Transactions;

public record SuiCertifiedTransaction(
    TransactionDigest TransactionDigest,
    SuiTransactionData Data,
    Signature Signature,
    AuthorityStrongQuorumSignInfo AuthSignInfo
);