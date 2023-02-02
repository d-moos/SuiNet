using System.Runtime.Serialization;

namespace Naami.SuiNet.Types;

[DataContract]
public record EventId(
    [property: DataMember(Name = "txDigest")] TransactionDigest TxDigest,
    [property: DataMember(Name = "eventSeq")]
    long EventSeq
);