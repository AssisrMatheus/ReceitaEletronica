using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using RM_e.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

[assembly: OwinStartup(typeof(WebApiApplication))]
namespace RM_e.WebService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);            
        }

        public void Configuration(IAppBuilder app)
        {
            var options = new CorsOptions();
            app.UseCors(options);

            var api = new HttpConfiguration();
            app.UseWebApi(api);
        }
    }
}
