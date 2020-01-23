using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

[ApiController]
[Route("[controller]")]
public class ValuesController : ControllerBase
{
    private ILogger<ValuesController> _logger;
    public ValuesController(ILogger<ValuesController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        _logger.LogInformation("Value controller is running.");
        List<string> list = await Task.Run(() =>
        {
            return new List<string> { "value1", "value2" };
        });
        return Ok(list);
    }

    [HttpPost]
    public async Task<IActionResult> SetValues([FromBody]ValuesRequest request)
    {
        if (request == null) return BadRequest(request);

        await Task.CompletedTask;
        return Ok(new object());

    }
}