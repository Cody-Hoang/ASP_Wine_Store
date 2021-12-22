using BTL_ASP.NET_Nhom7.Common;
using BTL_ASP.NET_Nhom7.DAO;
using BTL_ASP.NET_Nhom7.Models;
using BTL_ASP.NET_Nhom7.Models.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_ASP.NET_Nhom7.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var productDao = new ProductDao();
            ViewBag.NewProduct = productDao.ListNewProduct(4);
            ViewBag.ListHotsell = productDao.ListHotSell(4);
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            int totalProduct = 0;
            foreach(var item in list)
            {
                totalProduct += item.Quantity;
            }    
            ViewBag.TotalProduct = totalProduct;
            return PartialView(list);
        }
    }
}