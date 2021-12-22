using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BTL_ASP.NET_Nhom7
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
           name: "Add Cart",
           url: "them-gio-hang",
           defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
           namespaces: new[] { "BTL_ASP.NET_Nhom7.Controllers" }

       );
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
           name: "Register",
           url: "dang-ky",
           defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional },
           namespaces: new[] { "BTL_ASP.NET_Nhom7.Controllers" }

       );
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
           name: "CustomLogin",
           url: "dang-xuat",
           defaults: new { controller = "User", action = "Logout", id = UrlParameter.Optional },
           namespaces: new[] { "BTL_ASP.NET_Nhom7.Controllers" }

       );
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
           name: "Login",
           url: "dang-nhap",
           defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional },
           namespaces: new[] { "BTL_ASP.NET_Nhom7.Controllers" }

       );
            routes.MapRoute(
          name: "Cart",
          url: "gio-hang",
          defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
           namespaces: new[] { "BTL_ASP.NET_Nhom7.Controllers" }

      );
            routes.MapRoute(
          name: "Payment",
          url: "thanh-toan",
          defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
           namespaces: new[] { "BTL_ASP.NET_Nhom7.Controllers" }

      );
            routes.MapRoute(
          name: "Payment Success",
          url: "hoan-thanh",
          defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional },
           namespaces: new[] { "BTL_ASP.NET_Nhom7.Controllers" }

      );
routes.MapRoute(
name: "Payment Error",
url: "loi",
defaults: new { controller = "Cart", action = "Error", id = UrlParameter.Optional },
namespaces: new[] { "BTL_ASP.NET_Nhom7.Controllers" }

);
           routes.MapRoute(
name: "ListAllProducts",
url: "xem-tat-ca-san-pham",
defaults: new { controller = "Product", action = "ListAllProducts", id = UrlParameter.Optional },
namespaces: new[] { "BTL_ASP.NET_Nhom7.Controllers" }

);



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "BTL_ASP.NET_Nhom7.Controllers" }
            );



        }
    }
}
