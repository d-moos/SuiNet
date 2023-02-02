using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Event.Query;

public record ObjectEventQuery(ObjectId Object) : IEventQuery;