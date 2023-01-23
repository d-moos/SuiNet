using Naami.SuiNet.Apis.Event;
using Naami.SuiNet.Apis.Event.Filter;

namespace Naami.SuiNet.Tests.Integration;

public class EventApiSpecifications
{
    [Test]
    public async Task TransactionDigest()
    {
        var api = new EventApi(Utils.JsonRpcClient.Value);

        var page = await api.GetEvents(new TransactionEventFilter("GVCg1VF2tMthN21JK5T996w3Lg2QiJn8hgzNu1Tox6d9"));
        var i = 0;
    }
    
    [Test]
    public async Task MoveModule()
    {
        var api = new EventApi(Utils.JsonRpcClient.Value);

        var page = await api.GetEvents(new MoveModuleEventFilter(new MoveModule("0x2", "coin")));
        var i = 0;
    }
    
    
    [Test]
    public async Task MoveEvent()
    {
        var api = new EventApi(Utils.JsonRpcClient.Value);

        var page = await api.GetEvents(new MoveEventEventFilter("0x2::coin::CurrencyCreated<0x530de59d2b0f861a9d61896e585a47d1493b8576::eth::ETH>"));
        var i = 0;
    }
}