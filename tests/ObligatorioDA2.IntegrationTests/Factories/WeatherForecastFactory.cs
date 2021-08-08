using ObligatorioDA2.Domain.WeatherForecasts;

namespace ObligatorioDA2.IntegrationTests.Factories
{
    public static class WeatherForecastFactory
    {
        public static WeatherForecast New()
        {
            IWeatherForecastManager weatherForecastManager = new WeatherForecastManager();
            return weatherForecastManager.Build();
        } 
    }
}