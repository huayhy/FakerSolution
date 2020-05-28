using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Faker.Solution.EntityFrameworkCore;
using Faker.Solution.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Faker.Solution.Web.Tests
{
    [DependsOn(
        typeof(SolutionWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class SolutionWebTestModule : AbpModule
    {
        public SolutionWebTestModule(SolutionEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SolutionWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(SolutionWebMvcModule).Assembly);
        }
    }
}