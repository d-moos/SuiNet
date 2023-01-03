namespace Naami.SuiNet.Types;

public record SuiObjectRef(ObjectId ObjectId, SequenceNumber Version, ObjectDigest Digest);