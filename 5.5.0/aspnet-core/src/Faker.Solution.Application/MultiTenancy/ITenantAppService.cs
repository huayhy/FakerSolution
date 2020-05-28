using Abp.Application.Services;
using Faker.Solution.MultiTenancy.Dto;

namespace Faker.Solution.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

