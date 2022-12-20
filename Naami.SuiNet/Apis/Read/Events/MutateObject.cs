using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Read.Events;

public record MutateObject(ObjectId PackageId, string TransactionModule, SuiAddress Sender, string ObjectType, ObjectId ObjectId, SequenceNumber Version);