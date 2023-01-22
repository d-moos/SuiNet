using Naami.SuiNet.Apis.Governance;

namespace Naami.SuiNet.Tests.Integration.Apis.Governance;

public class GovernanceApiSpecification
{
    private readonly IGovernanceApi _governanceApi = new GovernanceApi(Utils.JsonRpcClient.Value);

    [Test]
    public async Task Foo()
    {
        var r = await _governanceApi.GetDelegatedStake(Utils.TestingSignerAddress);
        var i = 0;
    }
}