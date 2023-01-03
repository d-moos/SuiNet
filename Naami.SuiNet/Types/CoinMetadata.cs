namespace Naami.SuiNet.Types;

public record CoinMetadata(byte Decimals, string Name, string Symbol, string Description)
{
    public string? IconUrl { get; set; }
    public ObjectId? Id { get; set; }
}