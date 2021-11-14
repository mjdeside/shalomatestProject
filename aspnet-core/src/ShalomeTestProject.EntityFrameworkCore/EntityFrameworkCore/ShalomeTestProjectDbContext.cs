using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ShalomeTestProject.Authorization.Roles;
using ShalomeTestProject.Authorization.Users;
using ShalomeTestProject.MultiTenancy;

namespace ShalomeTestProject.EntityFrameworkCore
{
    public class ShalomeTestProjectDbContext : AbpZeroDbContext<Tenant, Role, User, ShalomeTestProjectDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Category.Category> People { get; set; }

        public virtual DbSet<Product.Product> Product{ get; set; }

        public ShalomeTestProjectDbContext(DbContextOptions<ShalomeTestProjectDbContext> options)
            : base(options)
        {

        }
    }
}
