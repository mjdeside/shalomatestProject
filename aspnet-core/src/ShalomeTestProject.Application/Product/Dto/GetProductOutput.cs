using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShalomeTestProject.Product.Dto
{

    [AutoMapTo(typeof(Product))]
    public class GetProductOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int TenantId { get; set; }
        public decimal Price { get; set; }
    }
}
