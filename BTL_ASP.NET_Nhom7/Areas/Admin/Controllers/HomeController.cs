using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BTL_ASP.NET_Nhom7.Models;

namespace BTL_ASP.NET_Nhom7.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        WineStoreDB db = new WineStoreDB();
        public ActionResult Index()
        {
            Reload();
             return View();
        }
        [HttpPost]
        public ActionResult Index(string start, string end)
        {
            Reload();

                DateTime startT = Convert.ToDateTime(start);
                DateTime endT = Convert.ToDateTime(end);
                ViewBag.CalculateIncome = Convert.ToDecimal(db.OrderDetails.Where(x => x.Order.CreateDate.Value >= startT && x.Order.CreateDate <= endT).Sum(x => x.Product.PurchasePrice * x.Quantity)).ToString("###,###");
                return View();
        }
        private void Reload()
        {
            ViewBag.HotSell = (from p in db.Product
                               let totalQuantity = (from odt in db.OrderDetails
                                                    join od in db.Order on odt.OrderId equals od.OrderId
                                                    where odt.ProductId == p.ProductId
                                                    select odt.Quantity).Sum()
                               where totalQuantity > 0
                               orderby totalQuantity descending
                               select p
               //select new
               //{
               //    p.ProductId,
               //    p.ProductName,
               //    p.PurchasePrice,
               //    TotalQuantity = totalQuantity
               //}
               //thoii bo di kho qua bo qua

               ).Take(3).ToList();//th
            //ViewBag.HotSell = Mapper.Map<IEnumerable<hotSell.GetType()>,IEnumerable<HotSell>>(hotSell);
            //bo di nhu nay cho nhanh
            ViewBag.ToTalCustomers = db.User.Count(x => x.GroupId == 2);
            ViewBag.ToTalOrders = db.Order.Count();
            ViewBag.ToTalProduct = db.Product.Count();
            ViewBag.ToTalProductWasSell = db.OrderDetails.Sum(x => x.Quantity);
            int thisMonth = Convert.ToInt16(DateTime.Now.Month);
            ViewBag.ThisMonthIncome = Convert.ToDecimal(db.OrderDetails.Where(x => x.Order.CreateDate.Value.Month == thisMonth).Sum(x => x.Product.PurchasePrice * x.Quantity)).ToString("###,###");

        }
    }
}