﻿using System.Web;
using System.Web.Mvc;

namespace BTL_ASP.NET_Nhom7
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
