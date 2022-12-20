using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.CoinRead;

public record CoinPage(Coin[] Data, ObjectId? NextCursor) : Page<Coin, ObjectId?>(Data, NextCursor);