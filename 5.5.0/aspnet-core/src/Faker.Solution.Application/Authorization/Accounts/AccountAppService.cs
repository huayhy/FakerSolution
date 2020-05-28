using System.Threading.Tasks;
using Abp.Configuration;
using Abp.Zero.Configuration;
using Faker.Solution.Authorization.Accounts.Dto;
using Faker.Solution.Authorization.Users;

namespace Faker.Solution.Authorization.Accounts
{
    /// <summary>
    /// 【主要模块】  <br/>
    /// 【功能描述】  ：账号管理服务<br/>
    /// 【创建日期】  ：2020.05.21 <br/>
    /// 【开发人员】  ：系统默认<br/>
    ///</summary>
    public class AccountAppService : SolutionAppServiceBase, IAccountAppService
    {
        // from: http://regexlib.com/REDetails.aspx?regexp_id=1923
        public const string PasswordRegex = "(?=^.{8,}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\\s)[0-9a-zA-Z!@#$%^&*()]*$";

        private readonly UserRegistrationManager _userRegistrationManager;

        public AccountAppService(
            UserRegistrationManager userRegistrationManager)
        {
            _userRegistrationManager = userRegistrationManager;
        }

        public async Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input)
        {
            var tenant = await TenantManager.FindByTenancyNameAsync(input.TenancyName);
            if (tenant == null)
            {
                return new IsTenantAvailableOutput(TenantAvailabilityState.NotFound);
            }

            if (!tenant.IsActive)
            {
                return new IsTenantAvailableOutput(TenantAvailabilityState.InActive);
            }

            return new IsTenantAvailableOutput(TenantAvailabilityState.Available, tenant.Id);
        }

        /// <summary>
        /// 【用户】注册新用户
        /// </summary>
        /// <remarks>
        /// 示例:<br/>
        /// </remarks>
        /// <param name="input">RegisterInput DTO 函数</param>
        /// <returns>用户UserDto</returns> 
      
        public async Task<RegisterOutput> Register(RegisterInput input)
        {
            var user = await _userRegistrationManager.RegisterAsync(
                input.Name,
                input.Surname,
                input.EmailAddress,
                input.UserName,
                input.Password,
                true // Assumed email address is always confirmed. Change this if you want to implement email confirmation.
            );

            var isEmailConfirmationRequiredForLogin = await SettingManager.GetSettingValueAsync<bool>(AbpZeroSettingNames.UserManagement.IsEmailConfirmationRequiredForLogin);

            return new RegisterOutput
            {
                CanLogin = user.IsActive && (user.IsEmailConfirmed || !isEmailConfirmationRequiredForLogin)
            };
        }
    }
}
