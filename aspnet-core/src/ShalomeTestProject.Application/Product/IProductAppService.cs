using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ShalomeTestProject.Product.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShalomeTestProject.Product
{
    public interface IProductAppService : IApplicationService
    {
        Task<PagedResultDto<GetProductOutputList>> GetAll(PageProductResultRequestDto input);
        Task CreateOrEdit(CreateOrEditProduct input);

        Task<CreateOrEditProduct> GetProductById(int id);
        Task Delete(int id);
    }
}
