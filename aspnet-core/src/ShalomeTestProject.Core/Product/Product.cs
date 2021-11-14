using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShalomeTestProject.Product
{
    [Table("Product")]
    public class Product : FullAuditedEntity, IMustHaveTenant
    {

        [Required]
        public string Name { get; set; }
     
        public string Description { get; set; }

        public virtual Category.Category Category { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public int TenantId { get ; set ; }
        public decimal Price { get; set; }
    }
}
