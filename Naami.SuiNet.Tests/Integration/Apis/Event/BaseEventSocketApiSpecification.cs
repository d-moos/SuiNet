using Naami.SuiNet.Apis.Event.SocketApi;

namespace Naami.SuiNet.Tests.Integration.Apis.Event;

public abstract class BaseEventSocketApiSpecification
{
    protected readonly EventSocketApi EventSocketApi;

    public BaseEventSocketApiSpecification()
    {
        EventSocketApi = new EventSocketApi("wss://sui-fullnode.naami.fi");
    }
}