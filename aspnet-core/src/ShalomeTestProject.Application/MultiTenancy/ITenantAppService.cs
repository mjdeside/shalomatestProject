using Abp.Application.Services;
using ShalomeTestProject.MultiTenancy.Dto;

namespace ShalomeTestProject.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

