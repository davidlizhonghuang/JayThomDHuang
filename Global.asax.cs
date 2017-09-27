using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.WebPages;
using WebJayThomDhuang.App_Start;

namespace WebJayThomDhuang
{
    public class MvcApplication : System.Web.HttpApplication
    {
        
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Bootstrapper.Run(); //map autofac

            DisplayModeProvider.Instance.Modes
            .Insert(0, new DefaultDisplayMode("Mobile")
            {
                ContextCondition = (context =>
                    context.GetOverriddenUserAgent().IndexOf
                    ("Android", StringComparison.OrdinalIgnoreCase) >= 0)
            });


        }

        protected void Application_EndRequest()
        {
            if (Context.Response.StatusCode == 404)
            {
                 Response.RedirectPermanent("/");
            }

            Exception ex = Server.GetLastError();
            
            if (ex is HttpAntiForgeryException)
            {
                Response.Clear();
                Server.ClearError(); //make sure you log the exception first -- use elmah
                Response.Redirect("/Account/AntiForgeryIssue", true);
            }
        }

    }
}
