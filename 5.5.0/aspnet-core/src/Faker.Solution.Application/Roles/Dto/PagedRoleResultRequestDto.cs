using Abp.Application.Services.Dto;

namespace Faker.Solution.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

