using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Event.SocketApi.Filter.Events;

public record PublishEvent(
    SuiAddress Sender,
    ObjectId PackageId,
    SequenceNumber Version,
    ObjectDigest Digest
);