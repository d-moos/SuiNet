using System.Security;
using System.Text;
using Naami.SuiNet.Types;
using Naami.SuiNet.Types.Delegation;

namespace Naami.SuiNet.Apis.Governance;

public interface IGovernanceApi
{
    public Task<DelegatedStake[]> GetDelegatedStake(SuiAddress owner);
    public Task<ValidatorMetadata[]> GetValidators();
    public Task<CommitteeInfoResponse> GetCommitteeInfo(EpochId? epoch = null);
    public Task<SuiSystemState> GetSuiSystemState();
}