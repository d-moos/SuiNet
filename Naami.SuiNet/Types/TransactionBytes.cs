using Naami.SuiNet.Types.Custom;

namespace Naami.SuiNet.Types;

public record TransactionBytes(string TxBytes, SuiObjectRef Gas, SequenceNumber Version);