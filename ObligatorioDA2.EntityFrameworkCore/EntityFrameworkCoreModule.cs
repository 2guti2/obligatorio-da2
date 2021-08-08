using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Microsoft.Extensions.Configuration;
using ObligatorioDA2.Domain;
using ObligatorioDA2.EntityFrameworkCore.EntityFrameworkCore;

namespace ObligatorioDA2.EntityFrameworkCore
{
    [DependsOn(
        typeof(DomainModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class EntityFrameworkCoreModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }
        
        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<Context>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        ContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        var configuration =
                            AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());
                        ContextConfigurer.Configure(options.DbContextOptions,
                            configuration.GetConnectionString("Default"));
                    }
                });
            }
        }
        
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(EntityFrameworkCoreModule).GetAssembly());
        }
    }
}