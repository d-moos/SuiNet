namespace Naami.SuiNet.JsonRpc;

public record ParamsResult<TResult>(long Subscription)
{
    public TResult? Result { get; set; }
    public object? Error { get; set; }
}