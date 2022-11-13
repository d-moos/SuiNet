using Naami.SuiSdk.Types.Custom;

namespace Naami.SuiSdk.Types.Events;

public record MutateObject(ObjectId PackageId, string TransactionModule, SuiAddress Sender, string ObjectType, ObjectId ObjectId, SequenceNumber Version);