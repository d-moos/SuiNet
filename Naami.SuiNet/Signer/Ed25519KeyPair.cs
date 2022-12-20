using NSec.Cryptography;

namespace Naami.SuiNet.Signer;

public class Ed25519KeyPair
{
    private readonly string _secretKey;
    
    public Key PrivateKey 
        => Key.Import(SignatureAlgorithm.Ed25519, RawPrivateKey, KeyBlobFormat.RawPrivateKey);

    public ReadOnlySpan<byte> RawPrivateKey 
        => Convert.FromBase64String(_secretKey).AsSpan()[33..];
    
    public ReadOnlySpan<byte> RawPublicKey 
        => Convert.FromBase64String(_secretKey).AsSpan()[1..33];
    
    public Ed25519KeyPair(string secretKey)
    {
        _secretKey = secretKey;
    }
}