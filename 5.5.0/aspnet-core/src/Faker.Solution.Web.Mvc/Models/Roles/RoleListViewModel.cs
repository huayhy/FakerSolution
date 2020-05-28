using System.Collections.Generic;
using Faker.Solution.Roles.Dto;

namespace Faker.Solution.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
