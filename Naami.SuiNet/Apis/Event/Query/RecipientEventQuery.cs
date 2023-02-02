using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Event.Query;

public record RecipientEventQuery(SuiAddress Recipient) : IEventQuery;