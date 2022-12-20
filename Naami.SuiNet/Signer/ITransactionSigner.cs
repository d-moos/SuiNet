namespace Naami.SuiNet.Signer;

public interface ITransactionSigner
{
    public string SignTransaction(Intent intent, byte[] txBytes, Ed25519KeyPair keyPair);
}