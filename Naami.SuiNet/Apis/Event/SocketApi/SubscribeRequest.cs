using Naami.SuiNet.Apis.Event.SocketApi.Filter;

namespace Naami.SuiNet.Apis.Event.SocketApi;

public record SubscribeRequest(ISuiEventFilter Filter);