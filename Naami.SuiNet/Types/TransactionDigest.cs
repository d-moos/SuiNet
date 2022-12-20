namespace Naami.SuiNet.Types;

public readonly struct TransactionDigest
{
    private readonly string _digest;

    public TransactionDigest(string digest)
    {
        // TODO: digest format validation
        
        _digest = digest;
    }

    public override string ToString() => _digest;

    public static implicit operator TransactionDigest(string digest) => new(digest);
    public static implicit operator string(TransactionDigest digest) => digest.ToString();
}