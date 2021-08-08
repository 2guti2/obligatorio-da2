using System.Collections.Generic;
using Abp.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ObligatorioDA2.Application.WeatherForecast;
using ObligatorioDA2.Domain;

namespace ObligatorioDA2.HttpApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : AbpController
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastAppService _weatherForecastAppService;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IWeatherForecastAppService weatherForecastAppService
        )
        {
            _logger = logger;
            _weatherForecastAppService = weatherForecastAppService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return _weatherForecastAppService.GetWeatherForecasts();
        }
    }
}
