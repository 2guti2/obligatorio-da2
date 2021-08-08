using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace ObligatorioDA2.Application
{
    [DependsOn(
        typeof(AbpAutoMapperModule))]
    public class ApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            var thisAssembly = typeof(ApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}