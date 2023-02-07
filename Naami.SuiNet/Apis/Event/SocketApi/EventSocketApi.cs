using System.Reactive.Linq;
using System.Reactive.Subjects;
using Microsoft.Extensions.Logging.Abstractions;
using Naami.SuiNet.Apis.Event.SocketApi.Filter;
using Naami.SuiNet.JsonRpc;
using Naami.SuiNet.Types;
using Naami.SuiNet.Types.Events;
using Naami.SuiNet.WebSocket;
using ServiceStack;
using ServiceStack.Text;
using Websocket.Client;

namespace Naami.SuiNet.Apis.Event.SocketApi;

public class EventSocketApi : IEventSocketApi
{
    private readonly string _websocketUrl;

    public EventSocketApi(string websocketUrl)
    {
        _websocketUrl = websocketUrl;
    }

    public async Task<IObservable<SuiEventEnvelope>> SubscribeEvent(ISuiEventFilter filter)
    {
        var ws = new WebsocketClient(new Uri(_websocketUrl));

        ws.ReconnectionHappened.Subscribe(_ => Subscribe(ws, filter));
        
        await ws.Start();
        
        return ws.MessageReceived
            .Select(x => x.Text.FromJson<SubscriptionResponse<SuiEventEnvelope>>())
            .Where(x => x.Params != null)
            .Select(x => x.Params!.Result!);
    }

    private void Subscribe(WebsocketClient client, ISuiEventFilter filter)
    {
        using var scope = JsConfig.BeginScope();
        scope.IncludeTypeInfo = false;
        scope.ExcludeTypeInfo = true;
        scope.TextCase = TextCase.CamelCase;
        var req = new Request<SubscribeRequest>("sui_subscribeEvent", Guid.NewGuid().ToString())
        {
            Params = new SubscribeRequest(filter)
        };
        
        client.Send(req.ToJson());
        
        scope.Dispose();
    }
}