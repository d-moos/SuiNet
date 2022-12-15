using Naami.SuiNet.Types.Custom;

namespace Naami.SuiNet.Types.Events;

public record MutateObject(ObjectId PackageId, string TransactionModule, SuiAddress Sender, string ObjectType, ObjectId ObjectId, SequenceNumber Version);