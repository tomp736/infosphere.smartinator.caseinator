using Microsoft.AspNetCore.Mvc;
using caseinator.core;
using caseinator.data;

namespace caseinator.webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class CaseinatorController : ControllerBase
{
    private readonly CaseinatorDataProvider _caseinatorDataProvider;

    private readonly ILogger<CaseinatorController> _logger;

    public CaseinatorController(
        ILogger<CaseinatorController> logger,
        CaseinatorDataProvider caseinatorDataProvider)
    {
        _logger = logger;
        _caseinatorDataProvider = caseinatorDataProvider;
    }

    [HttpGet(Name = "GetCaseinators")]
    public IEnumerable<Caseinator> Get()
    {
        return _caseinatorDataProvider.GetCaseinators();
    }

    [HttpGet("random")]
    public Caseinator GetRandom()
    {
        return _caseinatorDataProvider.RandomCaseinator();
    }
}
