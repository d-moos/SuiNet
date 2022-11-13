using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Naami.SuiSdk.JsonRpc;

[DataContract]
public record Request(string Method, string Id)
{
    [JsonPropertyName("jsonrpc")]
    [DataMember(Name = "jsonrpc")]
    public string JsonRpc => "2.0";


    [JsonPropertyName("params")]
    [DataMember(Name = "params")]
    public object[]? Params { get; set; }

    [JsonPropertyName("method")]
    [DataMember(Name = "method")]
    public string Method { get; set; } = Method;

    [JsonPropertyName("id")]
    [DataMember(Name = "id")]
    public string Id { get; set; } = Id;
}