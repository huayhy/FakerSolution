using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Faker.Solution.Roles.Dto;
using Faker.Solution.Users.Dto;

namespace Faker.Solution.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<bool> ChangePassword(ChangePasswordDto input);
    }
}
