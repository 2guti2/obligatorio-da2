﻿using System.Collections.Generic;
using Abp.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;
using ObligatorioDA2.Application.WeatherForecasts;
using ObligatorioDA2.Application.WeatherForecasts.Dtos;

namespace ObligatorioDA2.HttpApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : AbpController
    {
        private readonly IWeatherForecastAppService _weatherForecastAppService;

        public WeatherForecastController(
            IWeatherForecastAppService weatherForecastAppService
        )
        {
            _weatherForecastAppService = weatherForecastAppService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecastOutputDto> Get()
        {
            return _weatherForecastAppService.ReadWeatherForecasts();
        }

        /// <summary>
        /// Creates a WeatherForecast.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /WeatherForecast
        ///     {
        ///        "hiddenField": "some hidden info",
        ///        "temperatureC": 31
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        public WeatherForecastOutputDto Post(WeatherForecastInputDto input)
        {
            return _weatherForecastAppService.CreateWeatherForecast(input);
        }
    }
}
