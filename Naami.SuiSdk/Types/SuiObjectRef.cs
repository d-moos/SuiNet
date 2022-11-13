using Naami.SuiSdk.Types.Custom;

namespace Naami.SuiSdk.Types;

public record SuiObjectRef(ObjectId ObjectId, SequenceNumber Version, ObjectDigest Digest);