using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Read.Events;

public record DeleteObject(ObjectId PackageId, string TransactionModule, SuiAddress Sender, ObjectId ObjectId, SequenceNumber Version);