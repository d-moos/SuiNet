using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Event.SocketApi.Filter.Events;

public record NewObjectEvent(
    ObjectId PackageId,
    /** Identifier **/ string TransactionModule,
    SuiAddress Sender,
    Owner Recipient,
    SuiObjectType SuiObjectType,
    ObjectId ObjectId,
    SequenceNumber Version
);