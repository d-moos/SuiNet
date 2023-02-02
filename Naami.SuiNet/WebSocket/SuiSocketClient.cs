
using Microsoft.Extensions.Logging;
using Naami.SuiNet.Apis.Event.SocketApi.Filter;
using Naami.SuiNet.JsonRpc;
using Naami.SuiNet.Types.Events;
using Naami.SuiNet.Types.Transactions;
using ServiceStack;
using Websocket.Client;

namespace Naami.SuiNet.WebSocket;

public interface ISuiSocketClient
{
    public delegate void TransactionReceived(SuiEvent suiEvent);
    public delegate void EventReceived(SuiEvent suiEvent);
    public event TransactionReceived? OnTransactionReceived;
    public event EventReceived? OnEventReceived;
    
    public Task StartAsync();

}

public class SuiSocketClient : IDisposable, ISuiSocketClient
{
    private readonly WebsocketClient _websocketClient;
    private readonly ILogger<SuiSocketClient> _logger;


    public event ISuiSocketClient.TransactionReceived? OnTransactionReceived;
    public event ISuiSocketClient.EventReceived? OnEventReceived;

    public SuiSocketClient(string rpcNodeUrl, ILogger<SuiSocketClient> logger)
    {
        _logger = logger;
        _websocketClient = new WebsocketClient(new Uri(rpcNodeUrl));

        _websocketClient.ReconnectTimeout = TimeSpan.FromSeconds(15);
        _websocketClient.ReconnectionHappened.Subscribe(_ => SubscribeToTransactions());
        _websocketClient.MessageReceived.Subscribe(OnMessageReceived);
    }

    public Task StartAsync()
    {
        return _websocketClient.Start();
    }

    private void SubscribeToTransactions()
    {
        _logger.LogInformation("Reconnected - subscribing to node");
        
        var req = new Request("sui_subscribeTransaction", Guid.NewGuid().ToString());
        req.Params = new[] { "Any" };

        _websocketClient.Send(req.ToJson());
    }

    private void OnMessageReceived(ResponseMessage response)
    {
        var r = response.Text.FromJson<SubscriptionResponse<SuiTransactionResponse>>();
        var result = r.Result ?? r.Params?.Result;
        if (result != null)
        {
            foreach (var capturedEvent in result.Effects.Events ?? Array.Empty<SuiEvent>())
            {
                OnEventReceived?.Invoke(capturedEvent);
            }
        }
    }

    public void Dispose()
    {
        _websocketClient.Dispose();
    }
}