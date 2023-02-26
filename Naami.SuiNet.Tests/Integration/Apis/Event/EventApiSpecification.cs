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
        
        var query = new EventTypeQuery(EventType.TransferObject);

        var e = await EventApi.GetEvents(new TransactionEventQuery("DzVNETR3sqk6bpu7MAoS3qYTi7hWPixpaqkgsezQNSSC"));
        var newObject = e.Data.First().Event.NewObject;
        
        var r = await EventApi.GetEvents(query, limit: 100);
        
        Console.WriteLine(DateTime.Now);
        
        foreach (var suiEventEnvelope in r.Data)
        {
            var b = suiEventEnvelope.Event.TransferObject.Recipient.Ownership;
        }
        var i = 0;
    }
}