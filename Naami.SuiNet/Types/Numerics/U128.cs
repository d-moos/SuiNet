using System.Numerics;

namespace Naami.SuiNet.Types.Numerics;

public readonly struct U128
{
    private readonly string _u128;

    public U128(string u128)
    {
        _u128 = u128;
    }

    public override string ToString()
    {
        return _u128;
    }

    public static implicit operator BigInteger(U128 u128) => BigInteger.Parse(u128);
    public static implicit operator U128(BigInteger u128) => u128.ToString();
    
    public static implicit operator string(U128 u128) => u128.ToString();
    public static implicit operator U128(string u128) => new(u128);
}