using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Event.SocketApi.Filter.Events;

public record DeleteObjectEvent(
    ObjectId PackageId,
    /** Identifier **/ string TransactionModule,
    SuiAddress Sender,
    SuiObjectType SuiObjectType,
    ObjectId ObjectId
);