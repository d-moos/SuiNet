using System.Runtime.Serialization;

namespace Naami.SuiSdk.Types;

public class SharedOwnership
{
    [DataMember(Name = "initial_shared_version")]
    public long InitialSharedVersion { get; set; }
}