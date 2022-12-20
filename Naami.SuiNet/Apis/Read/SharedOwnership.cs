using System.Runtime.Serialization;

namespace Naami.SuiNet.Apis.Read;

public class SharedOwnership
{
    [DataMember(Name = "initial_shared_version")]
    public long InitialSharedVersion { get; set; }
}