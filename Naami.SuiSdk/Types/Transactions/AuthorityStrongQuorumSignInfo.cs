using Naami.SuiSdk.Types.Custom;

namespace Naami.SuiSdk.Types.Transactions;

public record AuthorityStrongQuorumSignInfo(EpochId Epoch, string Signature, byte[] SignersMap);