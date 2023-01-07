using Naami.SuiNet.JsonRpc;
using Naami.SuiNet.Signer;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Tests.Integration;

public static class Utils
{
    // public static Lazy<IJsonRpcClient> JsonRpcClient = new(new JsonRpcClient("http://127.0.0.1:9000"));
    public static Lazy<IJsonRpcClient> JsonRpcClient = new(new JsonRpcClient("https://fullnode.devnet.sui.io"));

    public static SuiAddress TestingSignerAddress => "0x88c7746e63ff557ab4ef2f018514681dcf025356";
    public static Ed25519KeyPair TestingKeyPair =>
        new("AFrIEQdGd8YODe+8xZMR7WIpm9iKBQKxVOcMlTcWnzarw3tuKjYlh/2EwI+pvhgIDdYK1RRdcsvJU2JGAjUia4U=");
    
    public static SuiObjectType SuiCoin => new("0x2::sui::SUI");
}