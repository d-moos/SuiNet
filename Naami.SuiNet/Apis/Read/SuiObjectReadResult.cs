using Naami.SuiNet.Types;
using ServiceStack;
using ServiceStack.Text;

namespace Naami.SuiNet.Apis.Read;

public struct SuiObjectReadResult<T>
{
    private readonly string _rawJson;
    
    public SuiObjectReadResult(string rawJson)
    {
        _rawJson = rawJson;
    }
    
    public SuiObject<T>? ExistsResult => ObjectStatus == ObjectStatus.Exists
        ? _rawJson.FromJson<JsonObject>().GetUnescaped("details").FromJson<SuiObject<T>>()
        : null;
    
    public ObjectId? NotExistsResult  => ObjectStatus == ObjectStatus.NotExists
        ? _rawJson.FromJson<JsonObject>().GetUnescaped("details").FromJson<ObjectId>()
        : null;
    
    public SuiObjectRef? DeletedResult  => ObjectStatus == ObjectStatus.Deleted
        ? _rawJson.FromJson<JsonObject>().GetUnescaped("details").FromJson<SuiObjectRef>()
        : null;

    public ObjectStatus ObjectStatus
    {
        get
        {
            var dictionary = _rawJson.FromJson<JsonObject>();
            var status = dictionary.GetUnescaped("status");
            return Enum.Parse<ObjectStatus>(status!);
        }
    }
}