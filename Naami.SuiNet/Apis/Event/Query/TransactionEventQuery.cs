using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Event.Query;

public record TransactionEventQuery(TransactionDigest Transaction) : IEventQuery;