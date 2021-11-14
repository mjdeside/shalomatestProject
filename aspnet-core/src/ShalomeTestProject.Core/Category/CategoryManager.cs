using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShalomeTestProject.Category
{
    public class CategoryManager : IDomainService, ICategoryManager
    {
        public readonly IRepository<Category, int> _categoryRepository;
        public CategoryManager(IRepository<Category, int> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Create(Category entity)
        {
            _categoryRepository.Insert(entity);
        }

        public void Delete(int Id)
        {
            var category = _categoryRepository.FirstOrDefault(e => e.Id == Id);

            if(category != null)
            {
                 _categoryRepository.Delete(Id);
            }
            else
            {
                throw new UserFriendlyException("No Category to Delete");
            }
        }
        public IEnumerable<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public void Update(Category entity)
        {
            _categoryRepository.Update(entity);
        }
    }
}
