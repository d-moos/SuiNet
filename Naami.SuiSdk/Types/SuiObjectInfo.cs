using Naami.SuiSdk.Types.Custom;

namespace Naami.SuiSdk.Types;

public record SuiObjectInfo(
    ObjectId ObjectId,
    SequenceNumber Version,
    ObjectDigest Digest,
    SuiObjectType Type,
    Owner Owner,
    TransactionDigest PreviousTransaction
);