using System.Runtime.Serialization;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Governance;

[DataContract]
public record CommitteeInfoResponse([property: DataMember(Name="epoch")]EpochId Epoch)
{
    // TODO: 
    // - Why is automatic snake_case deserialization failing?
    // - change the tuple deserialization on RPC side? @MystenLabs
    // -> pub committee_info: Option<Vec<(AuthorityName, StakeUnit)>>,
    [DataMember(Name="committee_info")]
    public object[][]? CommitteeInfo { get; set; }
}