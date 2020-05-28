using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Faker.Solution.Authorization;

namespace Faker.Solution
{
    [DependsOn(
        typeof(SolutionCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class SolutionApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<SolutionAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(SolutionApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
