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

using Abp.Application.Services.Dto;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Microsoft.AspNetCore.Mvc;
using Service.Demo.Application.DomainEntities.Member.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Demo.Application.DomainEntities.Member
{
    /// <summary>
    /// 【扩展模块】  <br/>
    /// 【功能描述】  ：企业管理扩展模块<br/>
    /// 【创建日期】  ：2020.05.21 <br/>
    /// 【开发人员】  ：华威<br/>
    ///</summary>
    [ApiExplorerSettings(GroupName = "Extend", IgnoreApi = false)]
    public class MemberAppService : DemoAppServiceBase, IMemberAppService
    {
        /// <summary>
        /// 【扩展模块】带查询条件的分页查询方法
        /// </summary>
        /// <remarks>
        /// 例子:
        /// 这是一个开发示例，目的了解API的开发机制<br/>
        /// 返回为分页过后的列表集合
        /// </remarks>
        /// <param name="input">GetMemberInput DTO 函数</param>
        /// <returns>用户UserDto</returns> 
        /// <response code="201">返回value字符串</response>
        /// <response code="400">如果id为空</response>  
        /// <returns></returns>
        public async Task<PagedResultDto<MemberListDto>> GetPaged(GetMemberInput input)
        {
            var entity = new MemberListDto()
            {
                Name = "模块化测试接口"
            };

            var entityListDtos = new List<MemberListDto>();

            entityListDtos.Add(entity);
            
            return new PagedResultDto<MemberListDto>(10, entityListDtos);
        }
    }
}
