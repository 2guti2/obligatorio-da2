using System;
using Abp.AutoMapper;
using Abp.Dependency;
using Abp.Modules;
using Abp.Net.Mail;
using Abp.TestBase;
using Abp.Zero.EntityFrameworkCore;
using Castle.MicroKernel.Registration;
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
            ServiceCollectionRegistrar.Register(IocManager);
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
    }
}