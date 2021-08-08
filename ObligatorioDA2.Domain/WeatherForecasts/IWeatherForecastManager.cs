using Abp.Domain.Services;

namespace ObligatorioDA2.Domain.WeatherForecasts
{
    public interface IWeatherForecastManager : IDomainService
    {
        void LoadCalculatedProps(WeatherForecast forecast);
    }
}