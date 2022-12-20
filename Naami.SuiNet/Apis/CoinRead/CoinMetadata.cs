using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.CoinRead;

public record CoinMetadata(byte Decimals, string Name, string Symbol, string Description)
{
    public string? IconUrl { get; set; }
    public ObjectId? Id { get; set; }
}