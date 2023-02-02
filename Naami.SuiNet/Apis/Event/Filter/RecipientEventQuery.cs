using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Event.Filter;

public record RecipientEventQuery(SuiAddress Recipient) : IEventQuery;