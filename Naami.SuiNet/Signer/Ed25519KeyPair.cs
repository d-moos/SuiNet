using Naami.SuiNet.Types;
using NSec.Cryptography;

namespace Naami.SuiNet.Signer;

public abstract class SuiKeyPair
{
    public SuiKeyPair(byte[] privateKey)
    {
        PrivateKey = privateKey;
    }
    
    public abstract SignatureScheme Scheme { get; }

    public abstract byte[] PublicKey { get; }
    public byte[] PrivateKey { get; init; }

    public abstract byte[] Sign(byte[] data);
    
    public SuiAddress Address
    {
        get
        {
            var hasher = new byte[PublicKey.Length + 1];
            Array.Copy(new[]{ (byte)Scheme }, hasher, 1);
            Array.Copy(PublicKey, 0, hasher, 1, PublicKey.Length);

            var blake = new Blake2b(32);
            var hash = blake.Hash(hasher);
            var address = Convert.ToHexString(hash)[0..SuiAddress.LENGTH];

            return $"0x{address.ToLower()}";
        }
    }
}

public class Ed25519KeyPair : SuiKeyPair
{
    private readonly Key _key;
    
    public override SignatureScheme Scheme => SignatureScheme.ED25519;
    public override byte[] PublicKey => _key.PublicKey.Export(KeyBlobFormat.RawPublicKey);
    public override byte[] Sign(byte[] data)
        => SignatureAlgorithm.Ed25519.Sign(_key, data);
    

    public Ed25519KeyPair(byte[] privateKey) : base(privateKey)
    {
        _key = Key.Import(SignatureAlgorithm.Ed25519, privateKey, KeyBlobFormat.RawPrivateKey);
    }
}