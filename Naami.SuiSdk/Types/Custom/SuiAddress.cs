namespace Naami.SuiSdk.Types.Custom;

public readonly struct SuiAddress
{
    private readonly string _address;

    public SuiAddress(string address)
    {
        // TODO: address format validation
        
        _address = address;
    }

    public override string ToString() => _address;

    public static implicit operator SuiAddress(string address) => new(address);
    public static implicit operator string(SuiAddress address) => address.ToString();
}