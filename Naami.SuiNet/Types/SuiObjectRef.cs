using Naami.SuiNet.Types.Custom;

namespace Naami.SuiNet.Types;

public record SuiObjectRef(ObjectId ObjectId, SequenceNumber Version, ObjectDigest Digest);