using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service.Demo.Application.DomainEntities.Member.Dtos
{
    /// <summary>
    /// 文章内容表的列表DTO
    /// <see cref="Article"/>
    /// </summary>
    public class MemberListDto: AuditedEntityDto<long>
    {
        /// <summary>
        /// 会员名称
        /// </summary>
        [Required(ErrorMessage = "会员名称不能为空！")]
        public string Name { get; set; }
    }
}
