using System.Threading.Tasks;
using ShalomeTestProject.Configuration.Dto;

namespace ShalomeTestProject.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
