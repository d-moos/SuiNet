using ServiceStack;

namespace Naami.SuiNet.Types.Events;

public record MoveEvent(ObjectId PackageId, string TransactionModule, SuiAddress Sender, SuiObjectType Type, byte[] Bcs)
{
    public ObjectDictionary? Fields { get; set; }
}