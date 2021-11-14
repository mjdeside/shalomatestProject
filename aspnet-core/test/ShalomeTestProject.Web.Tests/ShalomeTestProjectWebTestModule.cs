using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ShalomeTestProject.EntityFrameworkCore;
using ShalomeTestProject.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace ShalomeTestProject.Web.Tests
{
    [DependsOn(
        typeof(ShalomeTestProjectWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class ShalomeTestProjectWebTestModule : AbpModule
    {
        public ShalomeTestProjectWebTestModule(ShalomeTestProjectEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ShalomeTestProjectWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(ShalomeTestProjectWebMvcModule).Assembly);
        }
    }
}