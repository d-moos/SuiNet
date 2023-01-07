using System.Runtime.Serialization;

namespace Naami.SuiNet.Types;

[DataContract]
public record EventId(
    [property: DataMember(Name = "txSeq")] long TxSeq,
    [property: DataMember(Name = "eventSeq")]
    long EventSeq
);