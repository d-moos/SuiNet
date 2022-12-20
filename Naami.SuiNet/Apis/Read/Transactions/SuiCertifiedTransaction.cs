using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Read.Transactions;

public record SuiCertifiedTransaction(
    TransactionDigest TransactionDigest,
    SuiTransactionData Data,
    Signature Signature,
    AuthorityStrongQuorumSignInfo AuthSignInfo
);