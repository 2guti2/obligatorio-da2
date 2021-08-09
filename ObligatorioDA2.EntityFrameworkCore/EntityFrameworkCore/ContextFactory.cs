using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ObligatorioDA2.Domain.Web;

namespace ObligatorioDA2.EntityFrameworkCore.EntityFrameworkCore
{
    public class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<Context>();
            IConfigurationRoot configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ContextConfigurer.Configure(builder, configuration.GetConnectionString("Default"));

            return new Context(builder.Options);
        }
    }
}