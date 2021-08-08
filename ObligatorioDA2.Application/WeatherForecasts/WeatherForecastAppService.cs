using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Repositories;
using ObligatorioDA2.Application.WeatherForecasts.Dtos;
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

        public List<WeatherForecastOutputDto> ReadWeatherForecasts()
        {
            var forecasts = _weatherForecastRepository.GetAll().ToList();
            return ObjectMapper.Map<List<WeatherForecastOutputDto>>(forecasts);
        }

        public WeatherForecastOutputDto CreateWeatherForecast()
        {
            WeatherForecast forecast = _weatherForecastManager.Build();
            _weatherForecastRepository.Insert(forecast);
            
            // Insert into db and load forecast Id into instance
            CurrentUnitOfWork.SaveChanges();

            return ObjectMapper.Map<WeatherForecastOutputDto>(forecast);
        }
    }
}