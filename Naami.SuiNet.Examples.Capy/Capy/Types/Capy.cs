using System.Runtime.Serialization;
using Naami.SuiNet.Extensions.ModuleTypes.Sui;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Examples.Capy.Capy.Types;

[DataContract]
public record Capy(
    [property: DataMember(Name = "id")] Uid Id,
    [property: DataMember(Name = "gen")] uint Gen,
    [property: DataMember(Name = "url")] string Url,
    [property: DataMember(Name = "link")] string Link,
    [property: DataMember(Name = "genes")] SuiObjectField<Genes> Genes,
    [property: DataMember(Name = "dev_genes")]
    SuiObjectField<Genes> DevGenes,
    [property: DataMember(Name = "item_count")]
    byte ItemCount,
    [property: DataMember(Name = "attributes")]
    SuiObjectField<Attribute>[] Attributes
);