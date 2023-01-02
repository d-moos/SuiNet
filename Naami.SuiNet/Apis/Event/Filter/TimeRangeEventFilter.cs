namespace Naami.SuiNet.Apis.Event.Filter;

public record TimeRangeEventFilter(ulong StartTime, ulong EndTime) : IEventFilter;