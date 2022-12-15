using System.Runtime.Serialization;

namespace Naami.SuiNet.Types;

public class SharedOwnership
{
    [DataMember(Name = "initial_shared_version")]
    public long InitialSharedVersion { get; set; }
}