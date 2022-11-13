namespace Naami.SuiSdk.Types.Custom;

public readonly struct ObjectDigest
{
    private readonly string _digest;

    public ObjectDigest(string digest)
    {
        // TODO: digest format validation
        
        _digest = digest;
    }

    public override string ToString() => _digest;

    public static implicit operator ObjectDigest(string digest) => new(digest);
    public static implicit operator string(ObjectDigest digest) => digest.ToString();
}