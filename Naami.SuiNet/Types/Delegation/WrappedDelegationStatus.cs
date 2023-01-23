namespace Naami.SuiNet.Types.Delegation;

public record WrappedDelegationStatus
{
    public ActiveDelegationStatus? Active { get; init; }
}