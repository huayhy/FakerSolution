using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Faker.Solution.Configuration;
using Faker.Solution.Web;

namespace Faker.Solution.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class SolutionDbContextFactory : IDesignTimeDbContextFactory<SolutionDbContext>
    {
        public SolutionDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SolutionDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            SolutionDbContextConfigurer.Configure(builder, configuration.GetConnectionString(SolutionConsts.ConnectionStringName));

            return new SolutionDbContext(builder.Options);
        }
    }
}
