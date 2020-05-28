using System.Collections.Generic;
using Faker.Solution.Roles.Dto;

namespace Faker.Solution.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}