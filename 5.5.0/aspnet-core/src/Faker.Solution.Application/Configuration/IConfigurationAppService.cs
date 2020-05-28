using System.Threading.Tasks;
using Faker.Solution.Configuration.Dto;

namespace Faker.Solution.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
