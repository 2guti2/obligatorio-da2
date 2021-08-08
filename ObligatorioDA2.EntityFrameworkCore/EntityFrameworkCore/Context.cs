using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ObligatorioDA2.Domain.WeatherForecasts;

namespace ObligatorioDA2.EntityFrameworkCore.EntityFrameworkCore
{
    public class Context : AbpDbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public virtual DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}