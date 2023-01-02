using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Event.Filter;

public record RecipientEventFilter(SuiAddress Recipient) : IEventFilter;