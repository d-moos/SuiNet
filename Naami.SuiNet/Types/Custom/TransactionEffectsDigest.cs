namespace Naami.SuiNet.Types.Custom;

public readonly struct TransactionEffectsDigest
{
    private readonly string _digest;

    public TransactionEffectsDigest(string digest)
    {
        // TODO: digest format validation
        
        _digest = digest;
    }

    public override string ToString() => _digest;

    public static implicit operator TransactionEffectsDigest(string digest) => new(digest);
    public static implicit operator string(TransactionEffectsDigest digest) => digest.ToString();
}