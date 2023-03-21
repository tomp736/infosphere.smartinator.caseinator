using caseinator.core;

namespace caseinator.data;

public class CaseinatorDataProvider
{
    private readonly CaseinatorGitHubRepositoryClient _caseinatorGitHubRepositoryClient;
    private readonly List<CaseinatorGitHubRepositoryConfig> _caseinatorGitHubRepositoryConfig;
    private readonly Lazy<List<Caseinator>> _caseinatorsLazy;

    public CaseinatorDataProvider(CaseinatorGitHubRepositoryClient caseinatorGitHubRepositoryClient, List<CaseinatorGitHubRepositoryConfig> caseinatorGitHubRepositoryConfig)
    {
        _caseinatorGitHubRepositoryClient = caseinatorGitHubRepositoryClient;
        _caseinatorGitHubRepositoryConfig = caseinatorGitHubRepositoryConfig;
        _caseinatorsLazy = new Lazy<List<Caseinator>>(() => LoadCaseinatorsAsync().Result);
    }

    private async Task<List<Caseinator>> LoadCaseinatorsAsync()
    {
        var tasks = _caseinatorGitHubRepositoryConfig.Select(config => _caseinatorGitHubRepositoryClient.GetCaseinatorsAsync(config));
        var results = await Task.WhenAll(tasks);
        var allCaseinators = results.SelectMany(r => r.Caseinators).ToList();
        return allCaseinators;
    }

    public List<Caseinator> GetCaseinators()
    {
        return _caseinatorsLazy.Value;
    }

    public Caseinator RandomCaseinator()
    {
        Random r = new Random();
        int next = r.Next(0, _caseinatorsLazy.Value.Count);
        return _caseinatorsLazy.Value[next];        
    }
}