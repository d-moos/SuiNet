using NSec.Cryptography;

namespace Naami.SuiNet.Signer;

public class TransactionSigner : ITransactionSigner
{
    public string SignTransaction(Intent intent, byte[] txBytes, Ed25519KeyPair keyPair)
    {
        // merge intent with txBytes
        var mergedData = new byte[3 + txBytes.Length];
        Array.Copy(intent, 0, mergedData, 0, 3);
        Array.Copy(txBytes, 0, mergedData, 3, txBytes.Length - 3);
        
        var signature = SignatureAlgorithm.Ed25519.Sign(keyPair.PrivateKey , mergedData);
        var base64Signature = Convert.ToBase64String(signature);

        return base64Signature;
    }
}