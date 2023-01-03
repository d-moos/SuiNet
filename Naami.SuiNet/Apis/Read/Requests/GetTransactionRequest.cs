using System.Runtime.Serialization;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Read.Requests;

[DataContract]
public record GetTransactionRequest(
    [property: DataMember(Name = "digest")]
    TransactionDigest Digest);