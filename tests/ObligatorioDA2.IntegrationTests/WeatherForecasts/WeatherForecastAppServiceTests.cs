using System.Collections.Generic;
using System.Linq;
using ObligatorioDA2.Application.WeatherForecasts;
using ObligatorioDA2.Application.WeatherForecasts.Dtos;
using ObligatorioDA2.Domain.WeatherForecasts;
using ObligatorioDA2.IntegrationTests.Factories;
using Xunit;

namespace ObligatorioDA2.IntegrationTests.WeatherForecasts
{
    public class WeatherForecastAppServiceTests : IntegrationTestBase
    {
        private readonly IWeatherForecastAppService _weatherForecastAppService;

        public WeatherForecastAppServiceTests()
        {
            _weatherForecastAppService = Resolve<IWeatherForecastAppService>();
        }
        
        [Fact]
        public void Read_should_return_all_entities()
        {
            WeatherForecast forecast = WeatherForecastFactory.New();
            UsingDbContext(context => context.WeatherForecasts.Add(forecast));
            
            List<WeatherForecastOutputDto> result = _weatherForecastAppService.ReadWeatherForecasts();
            
            Assert.Single(result);
            UsingDbContext(context =>
            {
                WeatherForecastOutputDto resultForecast = result.First();
                WeatherForecast dbForecast = context.WeatherForecasts.First();
                
                Assert.Equal(resultForecast.Date, dbForecast.Date);
                Assert.Equal(resultForecast.Summary, dbForecast.Summary);
                Assert.Equal(resultForecast.TemperatureC, dbForecast.TemperatureC);
                Assert.Equal(resultForecast.TemperatureF, dbForecast.TemperatureF);
            });
        }
    }
}