namespace Naami.SuiNet.Types;

public readonly struct SuiAddress
{
    public const byte LENGTH = 40;
    
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