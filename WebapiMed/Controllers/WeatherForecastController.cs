using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebapiMed.Models;

namespace WebapiMed.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly SerilogSettings _serilogSettings;
        private readonly GoodmentsConfig _goodments;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IOptionsSnapshot<SerilogSettings> serilogSettings, GoodmentsConfig goodments)
        {
            _serilogSettings = serilogSettings.Value;
            _logger = logger;
            _goodments = goodments;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("~/api/compliances")]
        public IActionResult GetCompliances()
        {
            _logger.LogInformation($"Serilog Setting: {_serilogSettings.LoggingEndpoint}");
            var vm = new viewModel();
            var complianceList = vm.PopulateData().ToList();
            return Ok(complianceList);
        }
    }
}
