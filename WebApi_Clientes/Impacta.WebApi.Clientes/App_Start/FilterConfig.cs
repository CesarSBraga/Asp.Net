﻿using System.Web;
using System.Web.Mvc;

namespace Impacta.WebApi.Clientes
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
