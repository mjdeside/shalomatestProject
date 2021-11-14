using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShalomeTestProject.Category.Dto
{
    [AutoMapTo(typeof(Category))]
    public class GetCategoryOutput 
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
