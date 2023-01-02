using Naami.SuiNet.JsonRpc;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.CoinRead;

public class CoinReadApi : ICoinReadApi
{
    private readonly IJsonRpcClient _jsonRpcClient;

    public CoinReadApi(IJsonRpcClient jsonRpcClient)
    {
        _jsonRpcClient = jsonRpcClient;
    }

    public Task<CoinPage> GetCoins(SuiAddress owner, SuiObjectType coinType, ObjectId cursor, uint size)
    {
        const string method = "sui_getCoins";

        return _jsonRpcClient.SendAsync<CoinPage>(method, new object[]
        {
            owner,
            coinType,
            cursor,
            size
        });
    }

    public Task<CoinPage> GetCoins(SuiAddress owner, SuiObjectType coinType)
    {
        const string method = "sui_getCoins";

        return _jsonRpcClient.SendAsync<CoinPage>(method, new object[]
        {
            owner,
            coinType
        });
    }

    public Task<Balance[]> GetBalances(SuiAddress owner, SuiObjectType coinType)
    {
        const string method = "sui_getBalance";
        return _jsonRpcClient.SendAsync<Balance[]>(method, new object[]
        {
            owner,
            coinType
        });
    }

    public Task<Balance[]> GetBalances(SuiAddress owner)
    {
        const string method = "sui_getBalance";
        return _jsonRpcClient.SendAsync<Balance[]>(method, new object[]
        {
            owner
        });
    }

    public Task<Supply> GetTotalSupply(SuiObjectType coinType)
    {
        const string method = "sui_getTotalSupply";
        return _jsonRpcClient.SendAsync<Supply>(method, new object[]
        {
            coinType
        });
    }
    
    public Task<CoinMetadata> GetCoinMetaData(SuiObjectType coinType)
    {
        const string method = "sui_getCoinMetadata";
        return _jsonRpcClient.SendAsync<CoinMetadata>(method, new object[]
        {
            coinType
        });
    }
}