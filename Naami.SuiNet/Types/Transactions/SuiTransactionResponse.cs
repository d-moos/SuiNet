using System.Runtime.Serialization;

namespace Naami.SuiNet.Types.Transactions;

public record SuiTransactionResponse(SuiCertifiedTransaction Certificate, SuiTransactionEffects Effects)
{
    [DataMember(Name = "timestamp_ms")] public ulong? TimeStamp { get; set; }

    [DataMember(Name = "parsed_data")] public SuiParsedTransactionResponse? ParsedData { get; set; }
}