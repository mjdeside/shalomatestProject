using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using ShalomeTestProject.Configuration.Dto;

namespace ShalomeTestProject.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ShalomeTestProjectAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
