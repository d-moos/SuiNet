namespace Naami.SuiNet.Apis.Event.Query;

public record TimeRangeEventQuery(ulong StartTime, ulong EndTime) : IEventQuery;