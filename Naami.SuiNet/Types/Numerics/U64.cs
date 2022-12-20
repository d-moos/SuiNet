namespace Naami.SuiNet.Types.Numerics;

public readonly struct U64
{
    private readonly ulong _u64;

    public U64(string u64)
    {
        _u64 = ulong.Parse(u64);
    }
    
    public U64(ulong u64)
    {
        _u64 = u64;
    }

    public override string ToString()
    {
        return _u64.ToString();
    }

    public static implicit operator U64(string u64) => new(u64);
    public static implicit operator U64(ulong u64) => new(u64);
    
    public static implicit operator string(U64 u64) => u64.ToString();
    public static implicit operator ulong(U64 u64) => u64._u64;
}