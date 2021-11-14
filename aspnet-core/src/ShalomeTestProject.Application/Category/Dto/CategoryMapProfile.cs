using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShalomeTestProject.Category.Dto
{
    public class CategoryMapProfile : Profile
    {

        public CategoryMapProfile()
        {
            CreateMap<Category,CreateOrEditCategory >();
            CreateMap<Category, GetCategoryOutput>();
        }
    }
}
