using Naami.SuiNet.Apis.Event;
using Naami.SuiNet.Apis.Event.Filter;
using Naami.SuiNet.Extensions.ApiStreams;
using Naami.SuiNet.Extensions.Tests;

namespace Naami.SuiNet.Tests.Integration.Apis.Event;

public class EventApiSpecification : BaseEventApiSpecification
{
    [Test]
    public async Task Foo()
    {
        var r = EventApi.GetEventStream(
            new MoveEventEventQuery("0x02::devnet_nft::MintNFTEvent"));
        await foreach (var suiEventEnvelopes in r)
        {
            var i = 0;
        }
    }
}

public abstract class BaseEventApiSpecification
{
    protected readonly IEventApi EventApi;

    public BaseEventApiSpecification()
    {
        EventApi = new EventApi(Utils.JsonRpcClient.Value);
    }
}