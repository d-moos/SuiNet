using ServiceStack;

namespace Naami.SuiNet.Types.Delegation;

public readonly struct DelegationStatus
{
    private readonly string _rawJsonString;

    public DelegationStatus(string rawJsonString)
    {
        _rawJsonString = rawJsonString;
    }

    public Status Status
    {
        get
        {
            if (IsPendingDelegationStatus(_rawJsonString))
                return Status.Pending;

            if (IsActiveDelegationStatus(_rawJsonString))
                return Status.Active;

            throw new ArgumentException($"Unknown {nameof(Status)} type");
        }
    }

    public ActiveDelegationStatus? ActiveDelegationStatus => IsActiveDelegationStatus(_rawJsonString)
        ? _rawJsonString.FromJson<WrappedDelegationStatus>().Active
        : null;

    private static bool IsPendingDelegationStatus(string rawJson) =>
        rawJson.Contains(Status.Pending.ToString());

    private static bool IsActiveDelegationStatus(string rawJson) =>
        rawJson.Contains(Status.Active.ToString());
}