using System.Text.Json;

using caseinator.core;

namespace caseinator.data;

public class CaseinatorGitHubRepositoryClient
{
    private readonly HttpClient _httpClient;

    public CaseinatorGitHubRepositoryClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CaseinatorGitHubRepositoryResponse> GetCaseinatorsAsync(CaseinatorGitHubRepositoryConfig caseinatorGitHubRepositoryConfig)
    {
        CaseinatorGitHubRepositoryResponse caseinatorRepositoryResponse
            = new CaseinatorGitHubRepositoryResponse();

        try
        {
            var response = await _httpClient.GetAsync(caseinatorGitHubRepositoryConfig.Url);
            var jsonContent = await response.Content.ReadAsStringAsync();
            var caseinators = JsonSerializer.Deserialize<List<Caseinator>>(jsonContent);
            if (caseinators is not null)
            {
                caseinatorRepositoryResponse.Caseinators = caseinators;
            }
        }
        catch (HttpRequestException ex)
        {
            caseinatorRepositoryResponse.Message = ex.Message;
        }
        catch (JsonException ex)
        {
            caseinatorRepositoryResponse.Message = ex.Message;
        }
        catch (Exception ex)
        {
            caseinatorRepositoryResponse.Message = ex.Message;
        }

        return caseinatorRepositoryResponse;
    }
}