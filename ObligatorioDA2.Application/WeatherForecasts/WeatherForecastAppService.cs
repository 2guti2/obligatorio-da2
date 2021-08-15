using System.Collections.Generic;
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
            List<WeatherForecast> forecasts = _weatherForecastRepository.GetAllList();
            return ObjectMapper.Map<List<WeatherForecastOutputDto>>(forecasts);
        }

        public WeatherForecastOutputDto CreateWeatherForecast(WeatherForecastInputDto input)
        {
            var forecast = ObjectMapper.Map<WeatherForecast>(input);
            _weatherForecastManager.LoadCalculatedProps(forecast);
            _weatherForecastRepository.Insert(forecast);

            // Insert into db and load forecast Id into instance.
            // This is necessary because Abp handles a "Unit of Work" by app service method.
            // That means that record is inserted after the method ends (after instance is already mapped).
            // This results in a dto with Id == 0
            CurrentUnitOfWork.SaveChanges();

            return ObjectMapper.Map<WeatherForecastOutputDto>(forecast);
        }
    }
}