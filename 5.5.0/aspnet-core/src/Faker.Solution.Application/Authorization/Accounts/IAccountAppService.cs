using System.Threading.Tasks;
using Abp.Application.Services;
using Faker.Solution.Authorization.Accounts.Dto;

namespace Faker.Solution.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
