using Abp.Application.Services.Dto;

namespace ShalomeTestProject.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

