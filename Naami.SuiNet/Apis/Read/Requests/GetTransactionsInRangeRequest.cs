using System.Runtime.Serialization;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Read.Requests;

[DataContract]
public record GetTransactionsInRangeRequest(
    [property: DataMember(Name = "start")]
    SequenceNumber Start,
    [property: DataMember(Name = "end")]
    SequenceNumber End);