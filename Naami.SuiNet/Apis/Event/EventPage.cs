using Naami.SuiNet.Apis.CoinRead;

namespace Naami.SuiNet.Apis.Event;

public record EventPage(SuiEventEnvelope[] Data, EventId? NextCursor)
    : Page<SuiEventEnvelope, EventId>(Data, NextCursor);