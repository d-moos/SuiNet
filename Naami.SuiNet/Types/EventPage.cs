namespace Naami.SuiNet.Types;

public record EventPage(SuiEventEnvelope[] Data, EventId? NextCursor)
    : Page<SuiEventEnvelope, EventId>(Data, NextCursor);