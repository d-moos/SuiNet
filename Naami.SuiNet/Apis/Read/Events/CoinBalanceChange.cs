using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Read.Events;

public record CoinBalanceChange(
    ObjectId PackageId,
    string TransactionModule,
    SuiAddress Sender,
    BalanceChangeType ChangeType,
    Owner Owner,
    SuiObjectType CoinType,
    ObjectId CoinObjectId,
    SequenceNumber Version,
    long Amount
);