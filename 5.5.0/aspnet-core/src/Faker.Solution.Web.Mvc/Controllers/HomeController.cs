using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Faker.Solution.Controllers;

namespace Faker.Solution.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : SolutionControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
