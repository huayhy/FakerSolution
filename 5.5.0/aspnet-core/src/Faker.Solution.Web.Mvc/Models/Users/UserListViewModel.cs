using System.Collections.Generic;
using Faker.Solution.Roles.Dto;

namespace Faker.Solution.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
