using System.Collections.Concurrent;
using System.IO;
using Abp.Extensions;
using Microsoft.Extensions.Configuration;

namespace ObligatorioDA2.Domain.Web
{
    public static class AppConfigurations
    {
        private static readonly ConcurrentDictionary<string, IConfigurationRoot> ConfigurationCache;

        static AppConfigurations()
        {
            ConfigurationCache = new ConcurrentDictionary<string, IConfigurationRoot>();
        }

        public static IConfigurationRoot Get(string path, string environmentName = null)
        {
            var cacheKey = path + "#" + environmentName;
            return ConfigurationCache.GetOrAdd(
                cacheKey,
                _ => BuildConfiguration(path, environmentName)
            );
        }

        private static IConfigurationRoot BuildConfiguration(string path, string environmentName = null)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile(Path.Join(path, "appsettings.json"));

            if (!environmentName.IsNullOrWhiteSpace())
            {
                builder = builder.AddJsonFile($"appsettings.{environmentName}.json", optional: true);
            }

            return builder.Build();
        }
    }
}