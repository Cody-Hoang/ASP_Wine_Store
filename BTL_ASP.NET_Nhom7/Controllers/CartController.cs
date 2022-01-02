using BTL_ASP.NET_Nhom7.Common;
using BTL_ASP.NET_Nhom7.DAO;
using BTL_ASP.NET_Nhom7.Models;
using BTL_ASP.NET_Nhom7.Models.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BTL_ASP.NET_Nhom7.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";

        // GET: Car
        public ActionResult Index()
        {
            var cart = Session[CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            decimal total = 0;
            foreach(var item in list)
            {
                total +=Convert.ToDecimal( item.Product.PurchasePrice * item.Quantity);
            }    
            ViewBag.Total = total.ToString("#,###")+"  VNĐ";
            return View(list);
        }
        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            decimal total = 0;
            foreach (var item in list)
            {
                total += Convert.ToDecimal(item.Product.PurchasePrice * item.Quantity);
            }
            ViewBag.Total = total.ToString("#,###") + "  VNĐ";
            return View(list);
        }
        [HttpPost]
        public ActionResult Payment(string shipName, string mobile, string address, string email)
        {
            if(Session[CommonConstants.USER_SESSION_CUSTOM] == null)
            {
                return Redirect("/dang-ky");
                var user = new User();
                user.UserName = shipName;
                user.Phone = mobile;
                user.Email = email;
                user.Address = address;
                user.GroupId = 2;
                user.Password = "1234567";
                var order = new Order();
                order.CreateDate = DateTime.Now;
                order.ModifiedDate = DateTime.Now;
                order.Status = false;
                try
                {
                    WineStoreDB db = new WineStoreDB();
                    db.User.Add(user);
                    db.SaveChanges();
                    order.UserId = user.UserId;
                    db.Order.Add(order);
                    db.SaveChanges();
                    var cart = (List<CartItem>)Session[CartSession];
                    //decimal total = 0;
                    foreach(var item in cart)
                    {
                        var orderDetails = new OrderDetails();
                        orderDetails.OrderId = order.OrderId;
                        orderDetails.ProductId = item.Product.ProductId;
                        orderDetails.Quantity = item.Quantity;
                        orderDetails.Discount = 0;
                        db.OrderDetails.Add(orderDetails);
                        db.SaveChanges();
                        //var product = db.Product.Find(orderDetails.ProductId);
                        //product.Quantity -= orderDetails.Quantity;
                        //if (product.Quantity < 0)
                        //    return Redirect("/khong-du-so-luong");
                        //total += Convert.ToDecimal( orderDetails.Product.PurchasePrice * orderDetails.Quantity);

                    }
                    //string content = System.IO.File.ReadAllText(Server.MapPath("~/Assets/client/template/neworder.html"));

                    //content = content.Replace("{{CustomerName}}", shipName);
                    //content = content.Replace("{{Phone}}", mobile);
                    //content = content.Replace("{{Email}}", email);
                    //content = content.Replace("{{Address}}", address);
                    //content = content.Replace("{{Total}}", total.ToString("N0"));

                }
                catch (Exception)
                {
                    return Redirect("/loi");
                }
            }
            else
            {
                var customSession = (UserLogin)Session[Common.CommonConstants.USER_SESSION_CUSTOM];
                var order = new Order();
                order.CreateDate = DateTime.Now;
                order.ModifiedDate= DateTime.Now;
                order.UserId = Convert.ToInt32(customSession.UserId);
                order.Status= false;
                try
                {
                    WineStoreDB db = new WineStoreDB();
                    db.Order.Add(order);
                    db.SaveChanges();
                    var cart = (List<CartItem>)Session[CartSession];
                    foreach (var item in cart)
                    {
                        var orderDetails = new OrderDetails();
                        orderDetails.OrderId = order.OrderId;
                        orderDetails.ProductId = item.Product.ProductId;
                        orderDetails.Quantity = item.Quantity;
                        orderDetails.Discount = 0;
                        db.OrderDetails.Add(orderDetails);
                        db.SaveChanges();
                    }


                }
                catch (Exception)
                {
                    return Redirect("/loi");

                }
            }
                Session[CartSession] = null;
                return Redirect("/hoan-thanh");
        }
        public ActionResult Success()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult Payment(string shipName, string mobile, string address, string email)
        //{
        //    var order = new Order();
        //    order.CreateDate = DateTime.Now;
        //    order.User.Address = address;
        //    order.User.Phone = mobile;
        //    order.User.UserName = shipName;
        //    order.User.Email = email;

        //    try
        //    {
        //        var id = new OrderDao().Insert(order);
        //        var cart = (List<CartItem>)Session[CartSession];
        //        var detailDao = new Model.Dao.OrderDetailDao();
        //        decimal total = 0;
        //        foreach (var item in cart)
        //        {
        //            var orderDetail = new OrderDetail();
        //            orderDetail.ProductID = item.Product.ProductId;
        //            orderDetail.OrderID = id;
        //            orderDetail.Price = item.Product.Price;
        //            orderDetail.Quantity = item.Quantity;
        //            detailDao.Insert(orderDetail);

        //            total += (item.Product.Price.GetValueOrDefault(0) * item.Quantity);
        //        }
        //        string content = System.IO.File.ReadAllText(Server.MapPath("~/assets/client/template/neworder.html"));

        //        content = content.Replace("{{CustomerName}}", shipName);
        //        content = content.Replace("{{Phone}}", mobile);
        //        content = content.Replace("{{Email}}", email);
        //        content = content.Replace("{{Address}}", address);
        //        content = content.Replace("{{Total}}", total.ToString("N0"));
        //       // var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

        //        //new MailHelper().SendMail(email, "Đơn hàng mới từ OnlineShop", content);
        //        //new MailHelper().SendMail(toEmail, "Đơn hàng mới từ OnlineShop", content);
        //    }
        //    catch (Exception ex)
        //    {
        //        //ghi log
        //        return Redirect("/loi-thanh-toan");
        //    }
        //    return Redirect("/hoan-thanh");
        //}
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.ProductId == item.Product.ProductId);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Product.ProductId == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public ActionResult AddItem(long productId, int quantity)
        {
            var product = new ProductDao().ViewDetail(productId);
            var cart = Session[CommonConstants.CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Product.ProductId == productId))
                {

                    foreach (var item in list)
                    {
                        if (item.Product.ProductId == productId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    //tạo mới đối tượng cart item
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                //Gán vào session
                Session[CommonConstants.CartSession] = list;
            }
            else
            {
                //tạo mới đối tượng cart item
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                //Gán vào session
                Session[CommonConstants.CartSession] = list;
            }
            return RedirectToAction("Index");
        }
    }

}