namespace Naami.SuiNet.Types;

public record Coin(
    SuiObjectType CoinType,
    ObjectId CoinObjectId,
    SequenceNumber Version,
    ObjectDigest Digest,
    ulong Balance
);