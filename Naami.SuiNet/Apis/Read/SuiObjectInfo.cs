using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Read;

public record SuiObjectInfo(
    ObjectId ObjectId,
    SequenceNumber Version,
    ObjectDigest Digest,
    SuiObjectType Type,
    Owner Owner,
    TransactionDigest PreviousTransaction
);