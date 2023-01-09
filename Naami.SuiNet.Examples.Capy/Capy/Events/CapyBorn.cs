using System.Runtime.Serialization;
using Naami.SuiNet.Examples.Capy.Capy.Types;
using Naami.SuiNet.Types;
using Attribute = System.Attribute;

namespace Naami.SuiNet.Examples.Capy.Capy.Events;

[DataContract]
public record CapyBorn(
    [property: DataMember(Name = "id")] ObjectId Id,
    [property: DataMember(Name = "gen")] uint Gen,
    [property: DataMember(Name = "genes")] SuiObjectField<Genes> Genes,
    [property: DataMember(Name = "dev_genes")] SuiObjectField<Genes> DevGenes,
    [property: DataMember(Name = "attributes")] SuiObjectField<Attribute>[] Attributes,
    [property: DataMember(Name = "bred_by")] SuiAddress BredBy
)
{
    [property: DataMember(Name = "parent_one")]
    public ObjectId? ParentOne { get; set; }

    [property: DataMember(Name = "parent_two")]
    public ObjectId? ParentTwo { get; set; }
};