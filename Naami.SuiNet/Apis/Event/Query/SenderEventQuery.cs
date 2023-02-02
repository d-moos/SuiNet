using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Event.Query;

public record SenderEventQuery(SuiAddress Sender) : IEventQuery;