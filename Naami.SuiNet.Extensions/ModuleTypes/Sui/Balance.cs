namespace Naami.SuiNet.Extensions.ModuleTypes.Sui;

public readonly struct Balance
{
    private readonly string _value;

    public Balance(string value)
    {
        _value = value;
    }

    public static implicit operator Balance(string value) => new(value);
    public static implicit operator string(Balance balance) => balance._value;
}