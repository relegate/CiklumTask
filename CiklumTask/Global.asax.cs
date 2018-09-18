using CiklumTask.Modules.ItemsParser;
using CiklumTask.ViewModels;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CiklumTask
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfig.Initialize();
            ParserScheduler.Start();
        }
    }
}
