using Naami.SuiNet.Types;
using Naami.SuiNet.Types.Events;
using Naami.SuiNet.Types.Numerics;

namespace Naami.SuiNet.Apis.Event.SocketApi.Filter.Events;

public record CoinBalanceChangeEvent(
    ObjectId PackageId,
    /** Identifier **/ string TransactionModule,
    SuiAddress Sender,
    BalanceChangeType ChangeType,
    Owner Owner,
    SuiObjectType CoinType,
    ObjectId CoinObjectId,
    SequenceNumber Version,
    I128 Amount
);