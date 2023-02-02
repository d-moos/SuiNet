using Naami.SuiNet.Apis.Event.Query;

namespace Naami.SuiNet.Tests.Integration.Apis.Event;

public class EventApiSpecification : BaseEventApiSpecification
{
    [Test]
    public async Task Foo()
    {
        var r = await EventApi.GetEvents(
            new MoveEventEventQuery("0x05ec326f79d5edfd6156ac3c734a418627f091cb::event::PoolCreatedEvent"));
        var i = 0;
    }
}