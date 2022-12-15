using System.Runtime.Serialization;
using ServiceStack;

namespace Naami.SuiNet.Types;

public record SuiParsedData(DataType DataType)
{
    // SuiParsedMoveObject
    public string? Type { get; set; }
    
    // SuiParsedMoveObject
    [DataMember(Name = "has_public_transfer")]
    public bool? HasPublicTransfer { get; set; }

    // SuiParsedMoveObject
    public ObjectDictionary? Fields { get; set; }

    // SuiMovePackage
    public ObjectDictionary? Disassembled { get; set; }
}