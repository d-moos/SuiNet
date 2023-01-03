using Naami.SuiNet.JsonRpc;

namespace Naami.SuiSdk.Tests;

public static class Utils
{
    public static Lazy<IJsonRpcClient> JsonRpcClient = new(new JsonRpcClient("http://127.0.0.1:9000"));
}