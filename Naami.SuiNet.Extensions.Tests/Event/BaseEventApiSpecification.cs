using System.Diagnostics;
using Naami.SuiNet.Apis.Event;
using Naami.SuiNet.Apis.Event.Query;
using Naami.SuiNet.Apis.Read;
using Naami.SuiNet.Extensions.ApiStreams;
using Naami.SuiNet.Extensions.Tests;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Tests.Integration.Apis.Event;

public class EventApiSpecification : BaseEventApiSpecification
{
    [Test]
    public async Task Foo()
    {
        var read = new ReadApi(Utils.JsonRpcClient.Value);

        var query = new EventTypeQuery(EventType.Publish);
        var r = await EventApi.GetEvents(query, limit: 100);

        var metadataIds = new List<ObjectId>();

        await foreach (var suiEventEnvelopes in EventApi.GetEventStream(query, pageSize: 100))
        {
            var eventsReponse = await read.GetTransactions(suiEventEnvelopes
                .Where(x => x.Event.Publish!.Sender != "0x0000000000000000000000000000000000000000")
                .Select(x => x.TxDigest.Value).ToArray());

            metadataIds.AddRange(eventsReponse
                .SelectMany(x => x.Effects.Events)
                .Where(x => x.NewObject != null)
                .Where(x => x.NewObject.ObjectType.StartsWith("0x2::coin::CoinMetadata"))
                .Select(x => x.NewObject!.ObjectId));
            
            Assert.NotZero(eventsReponse.Length);

            var b = 0;
        }

        Console.WriteLine(metadataIds.Count);

        var i = 0;
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