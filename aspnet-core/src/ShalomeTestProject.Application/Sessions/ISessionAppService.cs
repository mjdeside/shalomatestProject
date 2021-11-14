using System.Threading.Tasks;
using Abp.Application.Services;
using ShalomeTestProject.Sessions.Dto;

namespace ShalomeTestProject.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
