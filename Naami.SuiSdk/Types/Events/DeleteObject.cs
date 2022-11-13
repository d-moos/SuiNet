using Naami.SuiSdk.Types.Custom;

namespace Naami.SuiSdk.Types.Events;

public record DeleteObject(ObjectId PackageId, string TransactionModule, SuiAddress Sender, ObjectId ObjectId, SequenceNumber Version);