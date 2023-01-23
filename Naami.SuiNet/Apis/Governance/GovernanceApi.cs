using Naami.SuiNet.Apis.Governance.Requests;
using Naami.SuiNet.JsonRpc;
using Naami.SuiNet.Types;
using Naami.SuiNet.Types.Delegation;
using ServiceStack.Text;

namespace Naami.SuiNet.Apis.Governance;

public class GovernanceApi : IGovernanceApi
{
    private readonly IJsonRpcClient _jsonRpcClient;

    public GovernanceApi(IJsonRpcClient jsonRpcClient)
    {
        _jsonRpcClient = jsonRpcClient;
    }

    public Task<DelegatedStake[]> GetDelegatedStake(SuiAddress owner)
    {
        using var jsScope = JsConfig.BeginScope();
        jsScope.TextCase = TextCase.SnakeCase;
        
        const string method = "sui_getDelegatedStakes";

        return _jsonRpcClient.SendAsync<DelegatedStake[], GetDelegatedStakeRequest>(
            method,
            new GetDelegatedStakeRequest(owner)
        );
    }

    public Task<ValidatorMetadata[]> GetValidators()
    {
        using var jsScope = JsConfig.BeginScope();
        jsScope.TextCase = TextCase.SnakeCase;
        
        const string method = "sui_getValidators";
        return _jsonRpcClient.SendAsync<ValidatorMetadata[]>(
            method
        );
    }

    public Task<CommitteeInfoResponse> GetCommitteeInfo(EpochId? epoch = null)
    {        
        using var jsScope = JsConfig.BeginScope();
        jsScope.TextCase = TextCase.SnakeCase;

        const string method = "sui_getCommitteeInfo";
        return _jsonRpcClient.SendAsync<CommitteeInfoResponse, GetCommitteeInfoRequest>(
            method,
            new GetCommitteeInfoRequest { Epoch = epoch}
        );
    }

    public Task<SuiSystemState> GetSuiSystemState()
    {
        using var jsScope = JsConfig.BeginScope();
        jsScope.TextCase = TextCase.SnakeCase;
        
        const string method = "sui_getSuiSystemState";
        return _jsonRpcClient.SendAsync<SuiSystemState>(
            method
        );
    }
}