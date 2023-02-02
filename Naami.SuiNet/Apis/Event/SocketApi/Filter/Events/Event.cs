using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Event.SocketApi.Filter.Events;

public record Event
{
    public MoveEvent? MoveEvent { get; set; }
    public PublishEvent? Publish { get; set; }
    public CoinBalanceChangeEvent? CoinBalanceChange { get; set; }
    public EpochId? EpochChange { get; set; }
    public SequenceNumber? Checkpoint { get; set; }
    public TransferObjectEvent? TransferObject { get; set; }
    public MutateObjectEvent? MutateObject { get; set; }
    public DeleteObjectEvent? DeleteObject { get; set; }
    public NewObjectEvent? NewObject { get; set; }
}