using System;
using System.Collections.Generic;
using System.Linq;

namespace ObligatorioDA2.Application.WeatherForecast
{
    public class WeatherForecastAppService : ApplicationServiceBase, IWeatherForecastAppService
    {
        private static readonly string[] Summaries = {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        
        public List<Domain.WeatherForecast> GetWeatherForecasts()
        {
            var rng = new Random();
            return 
                Enumerable.Range(1, 5).Select(index => new Domain.WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToList();
        }
    }
}