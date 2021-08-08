using System;
using Abp.Application.Services.Dto;

namespace ObligatorioDA2.Application.WeatherForecasts.Dtos
{
    public class WeatherForecastOutputDto : EntityDto
    {

        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }
        
        public int TemperatureF { get; set; }

        public string Summary { get; set; }
    }
}