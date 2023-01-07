namespace Naami.SuiNet.Types;

public record DynamicFieldPage(DynamicFieldInfo[] Data, ObjectId? NextCursor) : Page<DynamicFieldInfo, ObjectId?>(Data, NextCursor);