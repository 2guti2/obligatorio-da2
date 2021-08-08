using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ObligatorioDA2.Domain;
using ObligatorioDA2.EntityFrameworkCore;

namespace ObligatorioDA2.Application
{
    [DependsOn(
        typeof(AbpAutoMapperModule), typeof(EntityFrameworkCoreModule), typeof(DomainModule))]
    public class ApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            Assembly thisAssembly = typeof(ApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}