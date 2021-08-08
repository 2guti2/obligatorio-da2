using System;
using System.Data.Common;
using Abp.TestBase;
using Castle.MicroKernel.Registration;
using ObligatorioDA2.EntityFrameworkCore.EntityFrameworkCore;

namespace ObligatorioDA2.IntegrationTests
{
    public class IntegrationTestBase : AbpIntegratedTestBase<IntegrationTestsModule>
    {
        protected IntegrationTestBase()
        {
            Effort.Provider.EffortProviderConfiguration.RegisterProvider();
        }

        protected override void PreInitialize()
        {
            //Fake DbConnection using Effort!
            LocalIocManager.IocContainer.Register(
                Component.For<DbConnection>()
                    .UsingFactoryMethod(Effort.DbConnectionFactory.CreateTransient)
                    .LifestyleSingleton()
            );

            base.PreInitialize();
        }

        public void UsingDbContext(Action<Context> action)
        {
            using (var context = LocalIocManager.Resolve<Context>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        public T UsingDbContext<T>(Func<Context, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<Context>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}