using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Event.Filter;

public record MoveEventEventQuery(SuiObjectType MoveEvent) : IEventQuery;