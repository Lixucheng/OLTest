using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.UI.WebControls;

namespace OnlineLearning
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest()
        {
            HttpContext.Current.Items["_Singleton"] = new Models.Singleton();
        }

        protected void Application_EndRequest()
        {
            var sgt = HttpContext.Current.Items["_Singleton"] as Models.Singleton;
            if (sgt != null) sgt.Dispose();
            
            
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var response = base.Response;
            response.Redirect("http:127.0.0.1:8088/Error", false); 
        }

       

       

       

    }
}
