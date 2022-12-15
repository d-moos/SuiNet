using Naami.SuiNet.Types.Custom;

namespace Naami.SuiNet.Types;

public record SuiObjectInfo(
    ObjectId ObjectId,
    SequenceNumber Version,
    ObjectDigest Digest,
    SuiObjectType Type,
    Owner Owner,
    TransactionDigest PreviousTransaction
);