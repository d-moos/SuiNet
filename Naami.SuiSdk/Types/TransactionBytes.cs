using Naami.SuiSdk.Types.Custom;

namespace Naami.SuiSdk.Types;

public record TransactionBytes(string TxBytes, SuiObjectRef Gas, SequenceNumber Version);