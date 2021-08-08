using System;
using Microsoft.EntityFrameworkCore;
using Castle.MicroKernel.Registration;
using Castle.Windsor.MsDependencyInjection;
using Abp.Dependency;
using Microsoft.Extensions.DependencyInjection;
using ObligatorioDA2.EntityFrameworkCore.EntityFrameworkCore;

namespace ObligatorioDA2.IntegrationTests
{
    public static class ServiceCollectionRegistrar
    {
        public static void Register(IIocManager iocManager)
        {
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