using System.Threading.Tasks;
using Abp.Application.Services;
using Faker.Solution.Sessions.Dto;

namespace Faker.Solution.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
