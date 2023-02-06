namespace Naami.SuiNet.Apis.Event.Query;

public enum EventType
{
    MoveEvent,
    /// Module published
    Publish,
    /// Coin balance changing event
    CoinBalanceChange,
    /// Epoch change
    EpochChange,
    /// New checkpoint
    Checkpoint,

    /// Object level event
    /// Transfer objects to new address / wrap in another object
    TransferObject,

    /// Object level event
    /// Object mutated.
    MutateObject,
    /// Delete object
    DeleteObject,
    /// New object creation
    NewObject,
}

public record EventTypeQuery(EventType EventType) : IEventQuery;