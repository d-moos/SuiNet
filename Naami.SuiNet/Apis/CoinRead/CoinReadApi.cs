using Naami.SuiNet.Apis.CoinRead.Requests;
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
        
        return _jsonRpcClient.SendAsync<CoinPage, GetCoinsRequest>(method, new GetCoinsRequest(owner, coinType)
        {
            Cursor = cursor,
            Limit = size
        });
    }
    
    public Task<CoinPage> GetCoins(SuiAddress owner, SuiObjectType coinType, uint size)
    {
        const string method = "sui_getCoins";
        
        return _jsonRpcClient.SendAsync<CoinPage, GetCoinsRequest>(method, new GetCoinsRequest(owner, coinType)
        {
            Limit = size
        });
    }
    
    public Task<CoinPage> GetCoins(SuiAddress owner, SuiObjectType coinType, ObjectId cursor)
    {
        const string method = "sui_getCoins";
        return _jsonRpcClient.SendAsync<CoinPage, GetCoinsRequest>(method, new GetCoinsRequest(owner, coinType)
        {
            Cursor = cursor,
        });
    }

    public Task<CoinPage> GetCoins(SuiAddress owner, SuiObjectType coinType)
    {
        const string method = "sui_getCoins";
        return _jsonRpcClient.SendAsync<CoinPage, GetCoinsRequest>(method, new GetCoinsRequest(owner, coinType));
    }

    public Task<Balance[]> GetBalances(SuiAddress owner, SuiObjectType coinType)
    {
        const string method = "sui_getBalance";
        return _jsonRpcClient.SendAsync<Balance[], GetBalanceRequest>(method, new GetBalanceRequest(owner)
        {
            CoinType = coinType
        });
    }

    public Task<Balance[]> GetBalances(SuiAddress owner)
    {
        const string method = "sui_getBalance";
        return _jsonRpcClient.SendAsync<Balance[], GetBalanceRequest>(method, new GetBalanceRequest(owner));
    }
    
    public Task<Balance[]> GetAllBalances(SuiAddress owner)
    {
        const string method = "sui_getAllBalances";
        return _jsonRpcClient.SendAsync<Balance[], GetAllBalanceRequest>(method, new GetAllBalanceRequest(owner));
    }

    public Task<Supply> GetTotalSupply(SuiObjectType coinType)
    {
        const string method = "sui_getTotalSupply";
        return _jsonRpcClient.SendAsync<Supply, GetTotalSupplyRequest>(method, new GetTotalSupplyRequest(coinType));
    }
    
    public Task<CoinMetadata> GetCoinMetaData(SuiObjectType coinType)
    {
        const string method = "sui_getCoinMetadata";
        return _jsonRpcClient.SendAsync<CoinMetadata, GetCoinMetadataRequest>(method,
            new GetCoinMetadataRequest(coinType));
    }

    public async Task<CoinMetadata[]> GetCoinMetaDatas(params SuiObjectType[] coinTypes)
    {
        const string method = "sui_getCoinMetadata";
        var response =
            await _jsonRpcClient.SendBatchAsync<CoinMetadata, GetCoinMetadataRequest>(method,
                coinTypes.Select(x => new GetCoinMetadataRequest(x)).ToArray());

        return response;
        
    }
}