using IbrahimCarbugaBlog.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace IbrahimCarbugaBlog
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DbFactory.GonderiCrud.CheckConnection();
            DbFactory.KategoriCrud.CheckConnection();
            DbFactory.UserCrud.CheckConnection();
            DbFactory.YorumCrud.CheckConnection();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
    }
}
