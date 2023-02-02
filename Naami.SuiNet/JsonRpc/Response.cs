using System.Runtime.Serialization;

namespace Naami.SuiNet.JsonRpc;

[DataContract]
public record Response<TResult>(
    [property: DataMember(Name = "jsonrpc")]
    string JsonRpc,
    [property: DataMember(Name = "id")] string Id
)
{
    [property: DataMember(Name = "result")]
    public TResult? Result { get; set; }

    [property: DataMember(Name = "error")] public object? Error { get; set; }
}