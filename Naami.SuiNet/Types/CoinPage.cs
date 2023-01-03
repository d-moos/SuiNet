namespace Naami.SuiNet.Types;

public record CoinPage(Coin[] Data, ObjectId? NextCursor) : Page<Coin, ObjectId?>(Data, NextCursor);