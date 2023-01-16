namespace Naami.SuiNet.Types;

public enum SignatureScheme : byte
{
    ED25519 = 0x00,
    Secp256k1 = 0x01,
    Secp256r1 = 0x02,
    BLS12381 = 0xFF,
}