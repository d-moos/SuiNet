using Naami.SuiNet.Apis.Event.Query;
using Naami.SuiNet.Apis.Event.SocketApi.Filter;

namespace Naami.SuiNet.Tests.Integration.Apis.Event;

public class EventSocketApiSpecification : BaseEventSocketApiSpecification
{
    [Test]
    public async Task Foo()
    {
        var r = await EventSocketApi.SubscribeEvent(
            new EventTypeFilter(EventType.Publish));
        r.Subscribe(x =>
        {
                Console.WriteLine(x.Id);
        });
        

        await Task.Delay(100000);
    }
}