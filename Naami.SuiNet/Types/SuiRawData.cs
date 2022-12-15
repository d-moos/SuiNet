using System.Runtime.Serialization;
using Naami.SuiNet.Types.Custom;
using ServiceStack;

namespace Naami.SuiNet.Types;

public record SuiRawData(DataType DataType)
{
    public string? Type { get; set; }
    
    // SuiRawMoveObject
    [DataMember(Name = "has_public_transfer")]
    public bool? HasPublicTransfer { get; set; }

    // SuiRawMoveObject
    public SequenceNumber? Version { get; set; }

    // SuiRawMoveObject
    [DataMember(Name="bcs_bytes")]
    public string? BcsBytes { get; set; }

    // SuiRawMovePackage
    public ObjectId? Id { get; set; }
    
    // SuiRawMovePackage
    [DataMember(Name="module_map")]
    public ObjectDictionary? ModuleMap { get; set; }
}