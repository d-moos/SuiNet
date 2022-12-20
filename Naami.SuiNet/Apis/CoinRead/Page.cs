namespace Naami.SuiNet.Apis.CoinRead;

public record Page<TItem, TCursor>(TItem[] Data, TCursor? NextCursor);