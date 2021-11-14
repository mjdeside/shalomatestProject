using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ShalomeTestProject.Authorization;

namespace ShalomeTestProject
{
    [DependsOn(
        typeof(ShalomeTestProjectCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ShalomeTestProjectApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ShalomeTestProjectAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ShalomeTestProjectApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
