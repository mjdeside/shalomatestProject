using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ShalomeTestProject.EntityFrameworkCore
{
    public static class ShalomeTestProjectDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ShalomeTestProjectDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ShalomeTestProjectDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
