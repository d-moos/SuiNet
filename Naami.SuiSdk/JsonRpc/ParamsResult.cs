namespace Naami.SuiSdk.JsonRpc;

public record ParamsResult<TResult>(long Subscription)
{
    public TResult? Result { get; set; }
    public object? Error { get; set; }
}