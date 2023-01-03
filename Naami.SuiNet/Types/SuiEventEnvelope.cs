using Naami.SuiNet.Types.Events;

namespace Naami.SuiNet.Types;

public record SuiEventEnvelope(ulong Timestamp, EventId Id, SuiEvent Event)
{
    public TransactionDigest? TxDigest { get; set; }
}