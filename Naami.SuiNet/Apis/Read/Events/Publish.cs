using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Read.Events;

public record Publish(SuiAddress Sender, ObjectId PackageId);