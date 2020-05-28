/*
*┌────────────────────────────────────────────────┐
*│　描    述：扩展会员服务模块   
*│  部    门：质量架构部
*│　作    者：华威                                              
*│　版    本：1.0                                              
*│　创建时间：2020.05.27                        
*└────────────────────────────────────────────────┘
*/

/////////////////////////////////////////////////////////////////////////////////////////////////////
//                                              _ooOoo_                                            //
//                                             o8888888o                                           //
//                                             88" . "88                                           //
//                                             (| ^_^ |)                                           //
//                                             O\  =  /O                                           //
//                                          ____/`---'\____                                        //
//                                        .'  \\|     |//  `.                                      //
//                                       /  \\|||  :  |||//  \                                     //
//                                      /  _||||| -:- |||||-  \                                    //
//                                      |   | \\\  -  /// |   |                                    //
//                                      | \_|  ''\---/''  |   |                                    //
//                                      \  .-\__  `-`  ___/-. /                                    //
//                                    ___`. .'  /--.--\  `. . ___                                  //
//                                  ."" '<  `.___\_<|>_/___.'  >'"".                               //
//                                | | :  `- \`.;`\ _ /`;.`/ - ` : | |                              //
//                                \  \ `-.   \_ __\ /__ _/   .-` /  /                              //
//                          ========`-.____`-.___\_____/___.-`____.-'========                      //
//                                               `=---='                                           //
//                          ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^                     //
//                               佛祖保佑       永不宕机     永无BUG                               //
/////////////////////////////////////////////////////////////////////////////////////////////////////


using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Faker.Solution;

using System;

namespace Service.Demo.Application
{
    [DependsOn(
        typeof(SolutionCoreModule),
        typeof(AbpAutoMapperModule))]
    public class DemoApplicationModule: AbpModule
    {
        public override void PreInitialize()
        {
            
            // 配置授权
            //Configuration.Authorization.Providers.Add<SolutionAuthorizationProvider>();

        }

        public override void Initialize()
        {
            var thisAssembly = typeof(DemoApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );

        }
    }
}
