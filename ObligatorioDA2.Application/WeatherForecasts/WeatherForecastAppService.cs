using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Repositories;
using ObligatorioDA2.Domain.WeatherForecasts;

namespace ObligatorioDA2.Application.WeatherForecasts
{
    public class WeatherForecastAppService : ApplicationServiceBase, IWeatherForecastAppService
    {
        private readonly IRepository<WeatherForecast> _weatherForecastRepository;
        private readonly IWeatherForecastManager _weatherForecastManager;

        public WeatherForecastAppService(
            IRepository<WeatherForecast> weatherForecastRepository,
            IWeatherForecastManager weatherForecastManager
        )
        {
            _weatherForecastRepository = weatherForecastRepository;
            _weatherForecastManager = weatherForecastManager;
        }

        public List<WeatherForecast> ReadWeatherForecasts()
        {
            return _weatherForecastRepository.GetAll().ToList();
        }

        public void CreateWeatherForecast()
        {
            WeatherForecast forecast = _weatherForecastManager.Build();
            _weatherForecastRepository.Insert(forecast);
        }
    }
}