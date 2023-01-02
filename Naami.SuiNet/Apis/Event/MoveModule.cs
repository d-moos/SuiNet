using System.Runtime.Serialization;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Event;

[DataContract]
public record MoveModule(
    [property: DataMember(Name = "package")]
    ObjectId Package,
    [property: DataMember(Name = "module")]
    ObjectId Module
);