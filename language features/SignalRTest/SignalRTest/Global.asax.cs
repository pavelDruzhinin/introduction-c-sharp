using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.AspNet.SignalR;

namespace SignalRTest
{
    // Примечание: Инструкции по включению классического режима IIS6 или IIS7 
    // см. по ссылке http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            GlobalHost.Configuration.ConnectionTimeout = TimeSpan.FromSeconds(30);
            //GlobalHost.Configuration.DisconnectTimeout = TimeSpan.FromSeconds(40);

            SqlDependency.Start(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString);
            SqlDependency.Start(ConfigurationManager.ConnectionStrings["PetrocryptConnection"].ConnectionString);
        }

        protected void Application_End()
        {
            SqlDependency.Stop(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString);
            SqlDependency.Stop(ConfigurationManager.ConnectionStrings["PetrocryptConnection"].ConnectionString);
        }
    }
}