using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Event.SocketApi.Filter.Events;

public record MutateObjectEvent(
    ObjectId PackageId,
    /** Identifier **/ string TransactionModule,
    SuiAddress Sender,
    SuiObjectType SuiObjectType,
    ObjectId ObjectId,
    SequenceNumber Version
);