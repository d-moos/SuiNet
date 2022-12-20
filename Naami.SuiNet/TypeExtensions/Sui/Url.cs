namespace Naami.SuiNet.TypeExtensions.Sui;
public readonly struct Url
{
    private readonly string? _url;

    public Url(string? url)
    {
        _url = url;
    }

    public override string? ToString() => _url;

    public static implicit operator Url(string? url) => new(url);
    public static implicit operator string?(Url url) => url.ToString();
}