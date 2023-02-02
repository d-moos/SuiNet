using Naami.SuiNet.Apis.Event;
using Naami.SuiNet.Apis.Event.Filter;

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

public abstract class BaseEventApiSpecification
{
    protected readonly IEventApi EventApi;

    public BaseEventApiSpecification()
    {
        EventApi = new EventApi(Utils.JsonRpcClient.Value);
    }
}