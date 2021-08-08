using Abp.AspNetCore;
using ObligatorioDA2.Application;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace ObligatorioDA2.HttpApi
{
    [DependsOn(typeof(AbpAspNetCoreModule), typeof(ApplicationModule))]
    public class HttpApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(HttpApiModule).GetAssembly());
        }
    }
}