namespace Naami.SuiNet.JsonRpc;

public record SubscriptionResponse<TResult>(string JsonRpc, string Method)
{
    public TResult? Result { get; set; }
    public ParamsResult<TResult>? Params { get; set; }
}