using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Bwire.Aop;
using Bwire.Authorization;

namespace Bwire
{
    [DependsOn(
        typeof(BwireCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class BwireApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<BwireAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(BwireApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
