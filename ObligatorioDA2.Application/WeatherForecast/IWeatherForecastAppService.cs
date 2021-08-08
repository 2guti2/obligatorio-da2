using System.Collections.Generic;
using Abp.Application.Services;

namespace ObligatorioDA2.Application.WeatherForecast
{
    public interface IWeatherForecastAppService : IApplicationService
    {
        List<Domain.WeatherForecast> GetWeatherForecasts();
    }
}