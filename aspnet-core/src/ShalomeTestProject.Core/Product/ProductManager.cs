using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShalomeTestProject.Product
{
    public class ProductManager : IDomainService, IProductManager
    {
        private readonly IRepository<Product, int> _productRepository;
        public ProductManager(IRepository<Product, int> productRepository)
        {
            _productRepository = productRepository;
        }
        public void Create(Product entity)
        {
             _productRepository.Insert(entity);
        }

        public void Delete(int Id)
        {
            var product =  _productRepository.FirstOrDefault(e => e.Id == Id);

            if(product != null)
            {
                 _productRepository.Delete(Id);
            }
            else
            {
                throw new UserFriendlyException("No Product to Delete");
            }
        }

        public IEnumerable<Product> GetAll()
        {
           return _productRepository.GetAll().Include(e=>e.Category);
        }

        public void Update(Product entity)
        {
             _productRepository.Update(entity);
        }
    }
}
