using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Event.SocketApi.Filter.Events;

public record MoveEvent(
    ObjectId PackageId,
    /** Identifier **/ string TransactionModule,
    SuiAddress Sender,
    byte[] Contents
);