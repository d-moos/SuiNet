using Naami.SuiNet.JsonRpc;
using Naami.SuiNet.Signer;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Tests.Integration;

public static class Utils
{
    // public static Lazy<IJsonRpcClient> JsonRpcClient = new(new JsonRpcClient("http://127.0.0.1:9000"));
    public static Lazy<IJsonRpcClient> JsonRpcClient = new(new JsonRpcClient("https://fullnode.devnet.sui.io"));

    public static SuiAddress TestingSignerAddress => TestingKeyPair.Address;

    public static SuiKeyPair TestingKeyPair =>
        new Ed25519KeyPair(Convert.FromBase64String("AE58DGiYNCufJedwPwVvUNApEmLA4GP5fvW9nVOMJUjL")[1..]);

    public static SuiObjectType SuiCoin => new("0x2::sui::SUI");
}