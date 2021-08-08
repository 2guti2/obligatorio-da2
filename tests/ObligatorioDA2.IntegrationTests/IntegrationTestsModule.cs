using System;
using Abp.Dependency;
using Abp.Modules;
using Abp.TestBase;
using Castle.MicroKernel.Registration;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using ObligatorioDA2.Application;
using ObligatorioDA2.Domain;
using ObligatorioDA2.EntityFrameworkCore;
using ObligatorioDA2.EntityFrameworkCore.EntityFrameworkCore;

namespace ObligatorioDA2.IntegrationTests
{
    [DependsOn(
        typeof(AbpTestBaseModule),
        typeof(ApplicationModule),
        typeof(DomainModule),
        typeof(EntityFrameworkCoreModule))]
    public class IntegrationTestsModule : AbpModule
    {
        public IntegrationTestsModule(EntityFrameworkCoreModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        }

        public override void PreInitialize()
        {
            Configuration.UnitOfWork.Timeout = TimeSpan.FromMinutes(30);
            Configuration.UnitOfWork.IsTransactional = false;
        }

        public override void Initialize()
        {
            RegisterServiceCollections();
            RegisterFakeService<Context>();
        }

        private void RegisterFakeService<TService>() where TService : class
        {
            IocManager.IocContainer.Register(
                Component.For<TService>()
                    .UsingFactoryMethod(() => Substitute.For<TService>())
                    .LifestyleSingleton()
            );
        }

        private void RegisterServiceCollections()
        {
            IIocManager iocManager = IocManager;

            var services = new ServiceCollection();

            services.AddEntityFrameworkInMemoryDatabase();

            var serviceProvider = WindsorRegistrationHelper.CreateServiceProvider(iocManager.IocContainer, services);

            var builder = new DbContextOptionsBuilder<Context>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString()).UseInternalServiceProvider(serviceProvider);

            iocManager.IocContainer.Register(
                Component
                    .For<DbContextOptions<Context>>()
                    .Instance(builder.Options)
                    .LifestyleSingleton()
            );
        }
    }
}