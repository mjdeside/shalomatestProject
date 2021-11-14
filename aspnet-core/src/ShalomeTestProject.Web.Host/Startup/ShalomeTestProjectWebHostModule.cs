using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ShalomeTestProject.Configuration;

namespace ShalomeTestProject.Web.Host.Startup
{
    [DependsOn(
       typeof(ShalomeTestProjectWebCoreModule))]
    public class ShalomeTestProjectWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ShalomeTestProjectWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ShalomeTestProjectWebHostModule).GetAssembly());
        }
    }
}
