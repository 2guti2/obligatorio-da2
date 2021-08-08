using System;

namespace ObligatorioDA2.Domain.WeatherForecasts
{
    public class WeatherForecastManager : IWeatherForecastManager
    {
        private static readonly string[] Summaries = {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public void LoadCalculatedProps(WeatherForecast forecast)
        {
            var rng = new Random();
            forecast.Date = DateTime.Now;
            forecast.Summary = Summaries[rng.Next(Summaries.Length)];
        }
    }
}