using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Read.Events;

public record NewObject(
    ObjectId PackageId,
    string TransactionModule,
    SuiAddress Sender,
    Owner Recipient,
    string ObjectType,
    ObjectId ObjectId,
    SequenceNumber Version
);