using Naami.SuiNet.Types.Custom;

namespace Naami.SuiNet.Types.Events;

public record NewObject(
    ObjectId PackageId,
    string TransactionModule,
    SuiAddress Sender,
    Owner Recipient,
    string ObjectType,
    ObjectId ObjectId,
    SequenceNumber Version
);