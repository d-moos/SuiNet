using Naami.SuiSdk.Types.Custom;

namespace Naami.SuiSdk.Types.Events;

public record Publish(SuiAddress Sender, ObjectId PackageId);