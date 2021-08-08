using Abp.Modules;
using Abp.Reflection.Extensions;

namespace ObligatorioDA2.Domain
{
    public class DomainModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DomainModule).GetAssembly());
        }
    }
}