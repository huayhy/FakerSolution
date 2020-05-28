using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace Faker.Solution.Web.Views
{
    public abstract class SolutionRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected SolutionRazorPage()
        {
            LocalizationSourceName = SolutionConsts.LocalizationSourceName;
        }
    }
}
