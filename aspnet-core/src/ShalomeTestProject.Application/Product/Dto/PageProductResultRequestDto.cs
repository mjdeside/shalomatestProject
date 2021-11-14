using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShalomeTestProject.Product.Dto
{
    public class PageProductResultRequestDto : PagedResultRequestDto
    {
        public string filter { get; set; }
    }
}
