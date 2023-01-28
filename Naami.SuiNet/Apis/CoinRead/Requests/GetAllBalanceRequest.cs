using System.Runtime.Serialization;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.CoinRead.Requests;

[DataContract]
public record GetAllBalanceRequest([property: DataMember(Name = "owner")] SuiAddress Owner);