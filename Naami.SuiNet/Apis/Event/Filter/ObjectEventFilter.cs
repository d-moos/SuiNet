using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Event.Filter;

public record ObjectEventFilter(ObjectId Object) : IEventFilter;