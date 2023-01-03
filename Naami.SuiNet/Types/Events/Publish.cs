namespace Naami.SuiNet.Types.Events;

public record Publish(SuiAddress Sender, ObjectId PackageId);