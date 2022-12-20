namespace Naami.SuiNet.Types;

public readonly struct Signature
{
    private readonly string _signature;

    public Signature(string signature)
    {
        // TODO: digest format validation
        
        _signature = signature;
    }

    public override string ToString() => _signature;

    public static implicit operator Signature(string signature) => new(signature);
    public static implicit operator string(Signature signature) => signature.ToString();
}