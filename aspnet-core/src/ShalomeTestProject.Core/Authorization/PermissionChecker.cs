using Abp.Authorization;
using ShalomeTestProject.Authorization.Roles;
using ShalomeTestProject.Authorization.Users;

namespace ShalomeTestProject.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
