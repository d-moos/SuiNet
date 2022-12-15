using Naami.SuiNet.Types.Custom;

namespace Naami.SuiNet.Types.Events;

public record DeleteObject(ObjectId PackageId, string TransactionModule, SuiAddress Sender, ObjectId ObjectId, SequenceNumber Version);