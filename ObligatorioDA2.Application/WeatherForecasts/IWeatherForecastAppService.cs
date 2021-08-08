using System.Collections.Generic;
using Abp.Application.Services;
using ObligatorioDA2.Application.WeatherForecasts.Dtos;

namespace ObligatorioDA2.Application.WeatherForecasts
{
    public interface IWeatherForecastAppService : IApplicationService
    {
        List<WeatherForecastOutputDto> ReadWeatherForecasts();

        WeatherForecastOutputDto CreateWeatherForecast();
    }
}