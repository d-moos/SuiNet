namespace Naami.SuiNet.Apis.Read.Events;

// huge
public record SuiEvent
{
    public MoveEvent? MoveEvent { get; set; }
    public Publish? Publish { get; set; }
    public CoinBalanceChange? CoinBalanceChange { get; set; }
    public EpochChange? EpochChange { get; set; }
    public Checkpoint? Checkpoint { get; set; }
    public TransferObject? TransferObject { get; set; }
    public MutateObject? MutateObject { get; set; }
    public DeleteObject? DeleteObject { get; set; }
    public NewObject? NewObject { get; set; }
}



