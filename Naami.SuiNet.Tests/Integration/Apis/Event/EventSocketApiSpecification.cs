using Naami.SuiNet.Apis.Event.SocketApi.Filter;

namespace Naami.SuiNet.Tests.Integration.Apis.Event;

public class EventSocketApiSpecification : BaseEventSocketApiSpecification
{
    [Test]
    public async Task Foo()
    {
        var r = await EventSocketApi.SubscribeEvent(
            new AllFilter(
                new ISuiEventFilter[]
                {
                    new PackageFilter("0x2"),
                    new ModuleFilter("devnet_nft")
                }));
        r.Subscribe(x => Console.WriteLine(x.Id));
    }
}