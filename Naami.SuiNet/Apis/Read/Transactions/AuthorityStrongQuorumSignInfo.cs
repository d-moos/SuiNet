using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Read.Transactions;

public record AuthorityStrongQuorumSignInfo(EpochId Epoch, string Signature, byte[] SignersMap);