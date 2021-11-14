using Abp.Application.Services;
using ShalomeTestProject.Category.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShalomeTestProject.Category;
using System.Threading.Tasks;
using Abp.ObjectMapping;
using Abp.Authorization;
using ShalomeTestProject.Authorization;
using Abp.Domain.Uow;
using Abp.Collections.Extensions;
using Abp.Application.Services.Dto;

namespace ShalomeTestProject.Category
{
    [AbpAuthorize(PermissionNames.Pages_Category)]
    public class CategoryAppService : ApplicationService,ICategoryAppService
    {
        private readonly ICategoryManager _categoryManager;
        private readonly IObjectMapper _objectMapper;

        public CategoryAppService(ICategoryManager categoryManager, IObjectMapper objectMapper)
        {
            _categoryManager = categoryManager;
            _objectMapper = objectMapper;
        }

        public async Task CreateOrEdit(CreateOrEditCategory input)
        {

           if(input.TenantId == null)
           {

              input.TenantId = AbpSession.TenantId;
                
           }

           var category = _objectMapper.Map<Category>(input);

           if(input.Id == null)
            {

                _categoryManager.Create(category);
            }
            else
            {
                 _categoryManager.Update(category);
            }
        }

        public async Task Delete(int id)
        {
          
           _categoryManager.Delete(id);
            
        }
        public async Task<PagedResultDto<GetCategoryOutputList>> GetAllFilter(PagedCategoryResultRequestDto input)
        {
            var getCategory = _categoryManager.GetAll()
                .WhereIf(!string.IsNullOrEmpty(input.CategoryName), e => e.CategoryName.ToLower().Contains(input.CategoryName.ToLower()));

            var filterCategory = getCategory.Skip(input.SkipCount).Take(input.MaxResultCount);

            var getCategoryOutput = from x in filterCategory
                                    select new GetCategoryOutputList()
                                    {
                                        Category = _objectMapper.Map<GetCategoryOutput>(x)
                                    };

            return new PagedResultDto<GetCategoryOutputList>() { 
            TotalCount = filterCategory.Count(),
            Items = getCategoryOutput.ToList()
            };
        }
        public async Task FilterCategoryTest(PagedCategoryResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<CreateOrEditCategory> GetCategoryById(int id)
        {
            var category = _categoryManager.GetAll().FirstOrDefault(e => e.Id == id);

            return _objectMapper.Map<CreateOrEditCategory>(category);
        }

        public async Task<List<GetCategoryOutputList>> GetAll()
        {
            var getCategory = _categoryManager.GetAll();

            var categoryList = from x in getCategory
                               select new GetCategoryOutputList()
                               {
                                   Category = _objectMapper.Map<GetCategoryOutput>(x)
                               };

            return categoryList.ToList();
            
        }
    }
}
