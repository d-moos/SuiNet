using System.Runtime.Serialization;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Governance.Requests;

[DataContract]
public record GetCommitteeInfoRequest
{
    [DataMember(Name = "epoch")]
    public EpochId? Epoch { get; set; }
}