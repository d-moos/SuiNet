using Naami.SuiSdk.Types.Custom;
using ServiceStack;

namespace Naami.SuiSdk.Types.Events;

public record MoveEvent(ObjectId PackageId, string TransactionModule, SuiAddress Sender, SuiObjectType Type, byte[] Bcs)
{
    public ObjectDictionary? Fields { get; set; }
}