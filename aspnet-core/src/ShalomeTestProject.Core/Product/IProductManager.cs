using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShalomeTestProject.Product
{
    public interface IProductManager
    {
        IEnumerable<Product> GetAll();
        void Create(Product entity);
        void Update(Product entity);
        void Delete(int id);
    }
}
