using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Event.Query;

public record MoveEventEventQuery(SuiObjectType MoveEvent) : IEventQuery;