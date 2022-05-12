using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Bwire.Controllers
{
    public abstract class BwireControllerBase: AbpController
    {
        protected BwireControllerBase()
        {
            LocalizationSourceName = BwireConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
