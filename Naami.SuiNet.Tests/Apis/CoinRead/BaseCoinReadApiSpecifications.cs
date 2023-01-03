using Naami.SuiNet.Apis.CoinRead;
using Naami.SuiSdk.Tests;

namespace Naami.SuiNet.Tests.Apis.CoinRead;

public abstract class BaseCoinReadApiSpecifications
{
    protected readonly ICoinReadApi CoinReadApi;

    protected BaseCoinReadApiSpecifications()
    {
        CoinReadApi = new CoinReadApi(Utils.JsonRpcClient.Value);
    }
}