using Naami.SuiSdk.Types.Custom;

namespace Naami.SuiSdk.Types.Events;

public record CoinBalanceChange(ObjectId PackageId, string TransactionModule, SuiAddress Sender, BalanceChangeType ChangeType, Owner Owner, string CoinType, ObjectId CoinObjectId, SequenceNumber Version, long Amount);