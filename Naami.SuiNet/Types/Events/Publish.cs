using Naami.SuiNet.Types.Custom;

namespace Naami.SuiNet.Types.Events;

public record Publish(SuiAddress Sender, ObjectId PackageId);