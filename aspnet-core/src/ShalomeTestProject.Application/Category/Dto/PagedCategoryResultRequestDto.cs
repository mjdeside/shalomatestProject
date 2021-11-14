using Abp.Application.Services.Dto;
using System;

namespace ShalomeTestProject.Category.Dto
{
    public class PagedCategoryResultRequestDto : PagedResultRequestDto
    {
        public string CategoryName { get; set; }
    }
}
