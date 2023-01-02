using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Event.Filter;

public record SenderEventFilter(SuiAddress Sender) : IEventFilter;