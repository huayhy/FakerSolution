using Abp.AspNetCore.Mvc.ViewComponents;

namespace Faker.Solution.Web.Views
{
    public abstract class SolutionViewComponent : AbpViewComponent
    {
        protected SolutionViewComponent()
        {
            LocalizationSourceName = SolutionConsts.LocalizationSourceName;
        }
    }
}
