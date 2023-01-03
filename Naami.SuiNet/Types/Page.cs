namespace Naami.SuiNet.Types;

public record Page<TItem, TCursor>(TItem[] Data, TCursor? NextCursor);