using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShalomeTestProject.Product.Dto
{
    public class ProductMapProfile :Profile
    {
        public ProductMapProfile()
        {
            CreateMap<Product, CreateOrEditProduct>();
            CreateMap<Product, GetProductOutput>();
        }
    }
}
