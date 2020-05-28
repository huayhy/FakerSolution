using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Faker.Solution.Configuration.Dto;

namespace Faker.Solution.Configuration
{
    /// <summary>
    /// 【系统默认】  <br/>
    /// 【功能描述】  ：配置管理服务<br/>
    /// 【创建日期】  ：2020.05.21 <br/>
    /// 【开发人员】  ：系统默认<br/>
    ///</summary>
    [AbpAuthorize]
    public class ConfigurationAppService : SolutionAppServiceBase, IConfigurationAppService
    {
        /// <summary>
        /// 【用户】更改用户样式
        /// </summary>
        /// <remarks>
        /// 示例:<br/>
        /// </remarks>
        /// <param name="input">ChangeUiThemeInput DTO 函数</param>
        /// <returns>Task</returns> 
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
