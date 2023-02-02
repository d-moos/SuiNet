using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Event.Filter;

public record SenderEventQuery(SuiAddress Sender) : IEventQuery;