using System;
using Abp.TestBase;
using ObligatorioDA2.EntityFrameworkCore.EntityFrameworkCore;

namespace ObligatorioDA2.IntegrationTests
{
    public class IntegrationTestBase : AbpIntegratedTestBase<IntegrationTestsModule>
    {
        protected void UsingDbContext(Action<Context> action)
        {
            using var context = LocalIocManager.Resolve<Context>();
            action(context);
            context.SaveChanges();
        }

        protected T UsingDbContext<T>(Func<Context, T> func)
        {
            using var context = LocalIocManager.Resolve<Context>();
            T result = func(context);
            context.SaveChanges();

            return result;
        }
    }
}