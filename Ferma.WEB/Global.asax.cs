using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using Ferma.BLL.Infrastructure;
using Ferma.Modules;

namespace Ferma
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            NinjectModule userModule = new UserModule();
            NinjectModule typeProductModule = new TypeProductModule();
            NinjectModule typeBuildingsModule = new TypeBuildModule();
            NinjectModule serviceModule = new ServiceModule();
            var kernel = new StandardKernel(userModule,typeProductModule,typeBuildingsModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            kernel.Unbind<ModelValidatorProvider>();
        }
    }
}
