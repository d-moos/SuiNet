namespace Naami.SuiNet.Types.Transactions;

public record AuthorityStrongQuorumSignInfo(EpochId Epoch, string Signature, byte[] SignersMap);