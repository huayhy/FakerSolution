using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Faker.Solution.EntityFrameworkCore
{
    public static class SolutionDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<SolutionDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
            //builder.UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<SolutionDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
            //builder.UseMySql(connection);
        }
    }
}
