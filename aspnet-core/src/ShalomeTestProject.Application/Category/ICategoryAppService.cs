using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ShalomeTestProject.Category.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShalomeTestProject.Category
{
    public interface ICategoryAppService : IApplicationService
    {

        Task<PagedResultDto<GetCategoryOutputList>> GetAllFilter(PagedCategoryResultRequestDto input);

        Task<List<GetCategoryOutputList>> GetAll();

        Task CreateOrEdit(CreateOrEditCategory input);
        Task Delete(int id);
        Task<CreateOrEditCategory> GetCategoryById(int id);
    }
}
