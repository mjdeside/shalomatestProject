using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace ShalomeTestProject.Controllers
{
    public abstract class ShalomeTestProjectControllerBase: AbpController
    {
        protected ShalomeTestProjectControllerBase()
        {
            LocalizationSourceName = ShalomeTestProjectConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
