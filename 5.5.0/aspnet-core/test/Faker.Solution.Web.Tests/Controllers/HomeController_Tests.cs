using System.Threading.Tasks;
using Faker.Solution.Models.TokenAuth;
using Faker.Solution.Web.Controllers;
using Shouldly;
using Xunit;

namespace Faker.Solution.Web.Tests.Controllers
{
    public class HomeController_Tests: SolutionWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}