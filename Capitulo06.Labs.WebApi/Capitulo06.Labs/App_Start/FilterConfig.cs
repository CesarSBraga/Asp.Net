﻿using System.Web;
using System.Web.Mvc;

namespace Capitulo06.Labs
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
