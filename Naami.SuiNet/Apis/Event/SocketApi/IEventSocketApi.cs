using Naami.SuiNet.Apis.Event.SocketApi.Filter;
using Naami.SuiNet.Types;
using Websocket.Client;

namespace Naami.SuiNet.Apis.Event.SocketApi;

public interface IEventSocketApi
{
    public Task<IObservable<SuiEventEnvelope>> SubscribeEvent(ISuiEventFilter filter);
}