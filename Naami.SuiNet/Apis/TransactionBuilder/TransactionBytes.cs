using Naami.SuiNet.Apis.Read;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.TransactionBuilder;

public record TransactionBytes(string TxBytes, SuiObjectRef Gas, SequenceNumber Version);