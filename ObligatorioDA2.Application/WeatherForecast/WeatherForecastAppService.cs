using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Repositories;

namespace ObligatorioDA2.Application.WeatherForecast
{
    public class WeatherForecastAppService : ApplicationServiceBase, IWeatherForecastAppService
    {
        private readonly IRepository<Domain.WeatherForecast> _weatherForecastRepository;

        public WeatherForecastAppService(
            IRepository<Domain.WeatherForecast> weatherForecastRepository
        )
        {
            _weatherForecastRepository = weatherForecastRepository;
        }
        
        private static readonly string[] Summaries = {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        
        public List<Domain.WeatherForecast> ReadWeatherForecasts()
        {
            return _weatherForecastRepository.GetAll().ToList();
        }

        public void CreateWeatherForecast()
        {
            var rng = new Random();
            var forecast = new Domain.WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            };

            _weatherForecastRepository.Insert(forecast);
        }
    }
}