using System.Numerics;

namespace Naami.SuiNet.Types.Numerics;

public readonly struct U256
{
    private readonly string _u256;

    public U256(string u256)
    {
        _u256 = u256;
    }

    public override string ToString()
    {
        return _u256;
    }
    
    public static implicit operator BigInteger(U256 u256) => BigInteger.Parse(u256);
    public static implicit operator U256(BigInteger u256) => u256.ToString();
    
    public static implicit operator U256(string u256) => new(u256);
    public static implicit operator string(U256 u256) => u256.ToString();
}