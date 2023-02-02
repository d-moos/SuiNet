namespace Naami.SuiNet.Apis.Event.Filter;

public record TimeRangeEventQuery(ulong StartTime, ulong EndTime) : IEventQuery;