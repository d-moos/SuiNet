using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Event.Filter;

public record ObjectEventQuery(ObjectId Object) : IEventQuery;