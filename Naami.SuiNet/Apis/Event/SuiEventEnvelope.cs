using Naami.SuiNet.Apis.Read.Events;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Event;

public record SuiEventEnvelope(ulong Timestamp, EventId Id, SuiEvent Event)
{
    public TransactionDigest? TxDigest { get; set; }
}