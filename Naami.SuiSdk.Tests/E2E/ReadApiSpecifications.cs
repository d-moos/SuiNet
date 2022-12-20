using Naami.SuiNet.Apis;
using Naami.SuiNet.Apis.Read;
using Naami.SuiNet.JsonRpc;
using Naami.SuiNet.TypeExtensions.Sui;
using Naami.SuiNet.Types.Numerics;
using ServiceStack.Text;
using Shouldly;
using Coin = Naami.SuiNet.TypeExtensions.Sui.Coin;
using Balance = Naami.SuiNet.TypeExtensions.Sui.Balance;
using Supply = Naami.SuiNet.TypeExtensions.Sui.Supply;


namespace Naami.SuiSdk.Tests.E2E;

/// <summary>
/// In order to check if the RPC Endpoint still returns the data in a format we're expecting (casing, nested field structuring, ...)
/// we have to deploy an object (Lab) on-chain and read it through the API afterwards
/// </summary>
public class ReadApiSpecifications
{
    private Lab _lab;

    [OneTimeSetUp]
    public async Task Init()
    {
        JsConfig.TextCase = TextCase.SnakeCase;
        const string OnChainObject = "0xe7e8bfd5d4e878bc07f1841931a41790aed15376";
        var readApi = new ReadApi(new JsonRpcClient("https://fullnode.devnet.sui.io:443"));
        var readResult = await readApi.GetParsedObject<Lab>(OnChainObject);
        _lab = readResult.ExistsResult!.Data.Fields!;
    }

    [Test]
    public void Lab_Read_Bool()
    {
        _lab.Bool.ShouldBeTrue();
    }

    [Test]
    public void Lab_Read_Vector()
    {
        _lab.Vector.ShouldContain(c => c == 1);
        _lab.Vector.ShouldContain(c => c == 2);
        _lab.Vector.ShouldContain(c => c == 3);
    }

    [Test]
    public void Lab_Read_Balance()
    {
        // why is Balance a string (u64 is usually a number?)
        _lab.Balance.ShouldBe((Balance)"112233");
    }

    [Test]
    public void Lab_Read_Coin()
    {
        _lab.Coin.Fields.Balance.ShouldBe((Balance)"9876543210");
    }

    [Test]
    public void Lab_Read_Supply()
    {
        _lab.Supply.Fields.Value.ShouldBe((U64)112233);
    }

    [Test]
    public void Lab_Read_String()
    {
        _lab.AsciiString.ShouldBe("ascii_foo");
        _lab.UtfString.ShouldBe("utf_string");
    }

    [Test]
    public void Lab_Read_Bag()
    {
        _lab.Bag.Fields.Size.ShouldBe((U64)1);
    }

    [Test]
    public void Lab_Read_Numbers()
    {
        _lab.Char.ShouldBe((byte)1);
        _lab.Uint.ShouldBe((uint)2);
        _lab.Ushort.ShouldBe((ushort)6);
        _lab.Ulong.ShouldBe((U64)3);
        _lab.Ulonglong.ShouldBe((U128)"4");
        _lab.Ulonglonglong.ShouldBe((U256)"5");
    }

    [Test]
    public void Lab_Read_Url()
    {
        _lab.Url.ShouldBe((Url)"https://www.naami.fi");
    }

    [Test]
    public void Lab_Read_Option()
    {
        _lab.OptionObject!.Fields.MyValue.ShouldBe((byte)1);

        _lab.OptionAsciiString.ShouldBe("World");
        _lab.OptionUtfString.ShouldBe("Hello");
        _lab.OptionPrimitive.ShouldBe((byte)123);

        _lab.EmptyOptionPrimitive.ShouldBeNull();
    }
}

public record Lab(
    byte Char,
    ushort Ushort,
    uint Uint,
    U64 Ulong,
    U128 Ulonglong, // .NET types?
    U256 Ulonglonglong, // .NET types?
    string AsciiString,
    string UtfString,
    byte[] Vector,
    bool Bool,
    SuiObjectField<Coin> Coin,
    string CoinMetadata,
    Url Url,
    SuiObjectField<Bag> Bag,
    Balance Balance,
    SuiObjectField<Supply> Supply
)
{
    public byte? OptionPrimitive { get; init; }
    public byte? EmptyOptionPrimitive { get; init; }
    public string? OptionAsciiString { get; init; }
    public string? OptionUtfString { get; init; }
    public SuiObjectField<DummyObject>? OptionObject { get; init; }
}

public record DummyObject(byte MyValue);