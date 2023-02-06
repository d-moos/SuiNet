using Naami.SuiNet.Apis.Event.Query;
using Naami.SuiNet.Apis.Event.SocketApi.Filter.Events;
using Naami.SuiNet.Apis.Read;

namespace Naami.SuiNet.Tests.Integration.Apis.Event;

public class EventApiSpecification : BaseEventApiSpecification
{
    [Test]
    public async Task Foo()
    {
        Console.WriteLine(DateTime.Now);
        
        var read = new ReadApi(Utils.JsonRpcClient.Value);
        
        var query = new EventTypeQuery(EventType.Publish);
        var r = await EventApi.GetEvents(query, limit: 100);

        var events = await read.GetTransactions(r.Data
            .Where(x => x.Event.Publish!.Sender != "0x0000000000000000000000000000000000000000")
            .Select(x => x.TxDigest.Value).ToArray());
        
        Console.WriteLine(DateTime.Now);
        var i = 0;
    }
}