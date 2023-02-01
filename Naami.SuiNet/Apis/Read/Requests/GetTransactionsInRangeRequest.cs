using System.Runtime.Serialization;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Read.Requests;

[DataContract]
public record GetTransactionsInRangeRequest(
    [property: DataMember(Name = "start")]
    ulong Start,
    [property: DataMember(Name = "end")]
    ulong End);