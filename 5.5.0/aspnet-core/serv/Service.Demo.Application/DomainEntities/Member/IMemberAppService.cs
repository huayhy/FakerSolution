using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Service.Demo.Application.DomainEntities.Member.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Demo.Application.DomainEntities.Member
{
    public interface IMemberAppService: IApplicationService
    {
        Task<PagedResultDto<MemberListDto>> GetPaged(GetMemberInput input);
    }
}
