using System.Linq;
using ObligatorioDA2.Domain.WeatherForecasts;
using Xunit;

namespace ObligatorioDA2.UnitTests.Domain
{
    public class WeatherForecastManagerTests
    {
        private readonly IWeatherForecastManager _weatherForecastManager;
        private static readonly string[] Summaries = {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastManagerTests()
        {
            _weatherForecastManager = new WeatherForecastManager();
        }

        [Fact]
        public void Build_works_as_expected()
        {
            WeatherForecast forecast = _weatherForecastManager.Build();
            var isAny = Summaries.Any(s => s.Equals(forecast.Summary));
            Assert.True(isAny);
        }
    }
}
