using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Read;

public record SuiObjectRef(ObjectId ObjectId, SequenceNumber Version, ObjectDigest Digest);