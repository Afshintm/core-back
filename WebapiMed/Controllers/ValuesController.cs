using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebapiMed.Models;

[ApiController]
[Route("[controller]")]
public class ValuesController : ControllerBase
{
    private ILogger<ValuesController> _logger;
    private SerilogSettings _serilogSettings;
    public ValuesController(ILogger<ValuesController> logger, IOptionsSnapshot<SerilogSettings> serilogSettings,
    IOptionsSnapshot<GoodmentsConfig> goodmentsConfig)
    {
        _logger = logger;
        _serilogSettings = serilogSettings.Value;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var TransferId = 10;
        _logger.LogInformation("Value controller is running.{TransferId}", TransferId);
        List<string> list = await Task.Run(() =>
        {
            return new List<string> { _serilogSettings.LoggingEndpoint, _serilogSettings.MinimumLevel };
        });
        return Ok(list);
    }

    [HttpPost]
    public async Task<IActionResult> SetValues([FromBody] ValuesRequest request)
    {
        if (request == null) return BadRequest(request);

        await Task.CompletedTask;
        return Ok(new object());

    }
}