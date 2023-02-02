using System.Numerics;

namespace Naami.SuiNet.Types.Numerics;

public readonly struct I128
{
    private readonly string _i128;

    public I128(string i128)
    {
        _i128 = i128;
    }

    public override string ToString()
    {
        return _i128;
    }

    public static implicit operator BigInteger(I128 i128) => BigInteger.Parse(i128);
    public static implicit operator I128(BigInteger i128) => i128.ToString();
    
    public static implicit operator string(I128 i128) => i128.ToString();
    public static implicit operator I128(string i128) => new(i128);
}