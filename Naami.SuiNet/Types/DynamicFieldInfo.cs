namespace Naami.SuiNet.Types;

public record DynamicFieldInfo(
    string Name,
    DynamicFieldType Type,
    SuiObjectType ObjectType,
    ObjectId ObjectId,
    SequenceNumber Version,
    ObjectDigest Digest
);