using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Event.Filter;

public record TransactionEventFilter(TransactionDigest Transaction) : IEventFilter;