using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.ObjectMapping;
using ShalomeTestProject.Authorization;
using ShalomeTestProject.Category.Dto;
using ShalomeTestProject.Product.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShalomeTestProject.Product
{

    [AbpAuthorize(PermissionNames.Pages_Product)]
    public class ProductAppService : ApplicationService, IProductAppService
    {

        private readonly IObjectMapper _objectMapper;
        private readonly IProductManager _productManager;
        public ProductAppService(IObjectMapper objectMapper, IProductManager productManager)
        {
            _objectMapper = objectMapper;
            _productManager = productManager;
        }

        public async Task CreateOrEdit(CreateOrEditProduct input)
        {
            if(input.TenantId == null)
            {
                input.TenantId = AbpSession.TenantId;
            }

            var product = _objectMapper.Map<Product>(input);

            if(input.Id == null)
            {
                _productManager.Create(product);
            }
            else
            {
                _productManager.Update(product);
            }
        }

        public async Task Delete(int id)
        {
            _productManager.Delete(id);
        }

        public async Task<PagedResultDto<GetProductOutputList>> GetAll(PageProductResultRequestDto input)
        {
            var getProduct = _productManager.GetAll()
                    .WhereIf(!string.IsNullOrEmpty(input.filter),e=>
                    e.Description.ToLower().Contains(input.filter.ToLower()) || e.Name.ToLower().Contains(input.filter.ToLower()));

            var filterProduct = getProduct.Skip(input.SkipCount).Take(input.MaxResultCount);

            var getProductOutput = from x in filterProduct
                                   select new GetProductOutputList()
                                    {
                                        Category = _objectMapper.Map<GetCategoryOutput>(x.Category),
                                        Product = _objectMapper.Map<GetProductOutput>(x)
                                    };

            return new PagedResultDto<GetProductOutputList>() {
                Items = getProductOutput.ToList(),
                TotalCount = getProductOutput.Count()
            };
        }

        public async Task<CreateOrEditProduct> GetProductById(int id)
        {
            var product = _productManager.GetAll().FirstOrDefault(e => e.Id == id);

            return _objectMapper.Map<CreateOrEditProduct>(product);
        }

    }
}
