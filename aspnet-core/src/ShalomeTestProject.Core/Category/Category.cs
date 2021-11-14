using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShalomeTestProject.Category
{
    [Table("Category")]
    public class Category: FullAuditedEntity, IMustHaveTenant
    {

        [Required]
        [StringLength(10, ErrorMessage = "Maximum Length is 10")]
        public string CategoryName { get; set; }
        public int TenantId { get; set; }
    }
}
