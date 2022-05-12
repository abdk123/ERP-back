using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Bwire.EntityFrameworkCore;
using Bwire.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Bwire.Web.Tests
{
    [DependsOn(
        typeof(BwireWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class BwireWebTestModule : AbpModule
    {
        public BwireWebTestModule(BwireEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BwireWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(BwireWebMvcModule).Assembly);
        }
    }
}