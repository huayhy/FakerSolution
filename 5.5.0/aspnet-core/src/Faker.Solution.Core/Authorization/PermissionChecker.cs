using Abp.Authorization;
using Faker.Solution.Authorization.Roles;
using Faker.Solution.Authorization.Users;

namespace Faker.Solution.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
