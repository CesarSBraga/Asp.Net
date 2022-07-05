using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using System.Data.Entity;
using Impacta.WebApi.Clientes.Repository;

namespace Impacta.WebApi.Clientes
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

            // se nao estiver listada acima, deve ser incluida para que as configuraçoes
            //de banco de dados e API funcionem corretamente

            //GlobalConfiguration.Configure(WebApiConfig.Register);
            Database.SetInitializer(new DatabaseInitializer());

        }
    }
}
