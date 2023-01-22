using System.Runtime.Serialization;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Governance.Requests;

[DataContract]
public record GetDelegatedStakeRequest([property: DataMember(Name = "owner")] SuiAddress Owner);