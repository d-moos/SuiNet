using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.CoinRead;

public record Coin(
    SuiObjectType CoinType,
    ObjectId CoinObjectId,
    SequenceNumber Version,
    ObjectDigest Digest,
    ulong Balance
);