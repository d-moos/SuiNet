using Naami.SuiNet.Types;
using ServiceStack;

namespace Naami.SuiNet.Apis.Read.Events;

public record MoveEvent(ObjectId PackageId, string TransactionModule, SuiAddress Sender, SuiObjectType Type, byte[] Bcs)
{
    public ObjectDictionary? Fields { get; set; }
}