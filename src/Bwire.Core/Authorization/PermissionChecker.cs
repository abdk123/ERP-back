using Abp.Authorization;
using Bwire.Authorization.Roles;
using Bwire.Authorization.Users;

namespace Bwire.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
