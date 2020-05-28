using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Faker.Solution.Controllers;

namespace Faker.Solution.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : SolutionControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
