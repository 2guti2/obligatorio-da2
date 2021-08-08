using System.Collections.Generic;
using Abp.Application.Services;
using ObligatorioDA2.Domain.WeatherForecasts;

namespace ObligatorioDA2.Application.WeatherForecasts
{
    public interface IWeatherForecastAppService : IApplicationService
    {
        List<WeatherForecast> ReadWeatherForecasts();

        void CreateWeatherForecast();
    }
}