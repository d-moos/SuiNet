using Naami.SuiSdk.Types.Custom;

namespace Naami.SuiSdk.Types.Events;

public record TransferObject(
    ObjectId PackageId,
    string TransactionModule,
    SuiAddress Sender,
    Owner Recipient,
    string ObjectType,
    ObjectId ObjectId,
    SequenceNumber Version
);