using Abp.Dependency;
using Abp.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bwire.Aop
{
    public class InterceptionDemoApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            MeasureDurationInterceptorRegistrar.Initialize(IocManager.IocContainer.Kernel);
        }

        //...
    }
}
