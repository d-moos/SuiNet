using Naami.SuiNet.Apis;
using Naami.SuiNet.Apis.CoinRead;
using Naami.SuiNet.JsonRpc;

namespace Naami.SuiSdk.Tests.E2E;

public class CoinReadApiSpecifications
{
    private readonly ICoinReadApi _coinReadApi 
        = new CoinReadApi(new JsonRpcClient("https://fullnode.devnet.sui.io:443"));

    private const string WalletAddress = "0x32bc77aa13d2a5e59d6771dbcd8021601f413f5c";
    
    [Test]
    public async Task GetCoins()
    {
        var response = await _coinReadApi.GetCoins(WalletAddress, "0x2::sui::SUI");
        var f = 2;
    }
    
    [Test]
    public async Task GetBalances()
    {
        var response = await _coinReadApi.GetBalances(WalletAddress);
        var f = 2;
    }
    
    
    [Test]
    public async Task GetTotalSupply()
    {
        var response = await _coinReadApi.GetTotalSupply("0x2::sui::SUI");
        var f = 2;
    }
    
    
    
    [Test]
    public async Task GetCoinMetaData()
    {
        var response = await _coinReadApi.GetCoinMetaData("0x2::sui::SUI");
        var f = 2;
    }
}