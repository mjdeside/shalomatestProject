using ShalomeTestProject.Category.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShalomeTestProject.Product.Dto
{
    public class GetProductOutputList
    {
        public GetCategoryOutput Category { get; set; }
        public GetProductOutput Product { get; set; }
    }
}
