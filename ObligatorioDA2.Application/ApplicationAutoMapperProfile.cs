using AutoMapper;
using ObligatorioDA2.Application.WeatherForecasts.Dtos;
using ObligatorioDA2.Domain.WeatherForecasts;

namespace ObligatorioDA2.Application
{
    public class ApplicationAutoMapperProfile : Profile
    {
        public ApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<WeatherForecast, WeatherForecastOutputDto>();
            CreateMap<WeatherForecastInputDto, WeatherForecast>();
        }
    }
}