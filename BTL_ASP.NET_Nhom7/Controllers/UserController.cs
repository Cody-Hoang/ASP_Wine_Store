using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_ASP.NET_Nhom7.Common;
using BTL_ASP.NET_Nhom7.Models;
using BTL_ASP.NET_Nhom7.Models.Custom;
namespace BTL_ASP.NET_Nhom7.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        WineStoreDB db = new WineStoreDB();
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if(ModelState.IsValid)
            {
                var checkName = db.User.Count(x => x.UserName == model.UserName);
                ViewBag.Success = "";
                if(checkName > 0)
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else
                {
                    var user = new User();
                    user.UserName = model.UserName;
                    user.Password = model.Password; 
                    user.Email = model.Email;
                    user.Phone = model.Phone;
                    user.Address = model.Address;
                    user.CreateDate = DateTime.Now;
                    user.ModifiedDate = DateTime.Now;
                    user.Status = true;
                    user.GroupId = 2;
                    try
                    {
                        db.User.Add(user);
                        db.SaveChanges();
                        ViewBag.Success = "Đăng ký thành công";
                        var usersession = new UserLogin();
                        usersession.UserId = user.UserId;
                        usersession.UserName = user.UserName;
                        usersession.Email = user.Email;
                        usersession.Phone = user.Phone;
                        usersession.Address = user.Address;
                        Session.Add(Common.CommonConstants.USER_SESSION_CUSTOM, usersession);
                        return Redirect("/");
                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError("", "Có lỗi xảy ra, vui lòng thử lại");
                    }
                }    
            }    
            return View(model);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            ViewBag.Success = null;
            ViewBag.Error = null;
            if (ModelState.IsValid)
            {
                model.UserName = Request["username"];
                model.Password = Request["password"];
                int res = db.User.Count(x => x.UserName == model.UserName && x.Password == model.Password);
                if(res == 1)
                {

                    var user = db.User.SingleOrDefault(x => x.UserName == model.UserName);
                    var usersession = new UserLogin();
                    usersession.UserId = user.UserId;
                    usersession.UserName = user.UserName;
                    usersession.Email = user.Email;
                    usersession.Phone = user.Phone;
                    usersession.Address = user.Address;
                    Session.Add(Common.CommonConstants.USER_SESSION_CUSTOM, usersession);
                    ViewBag.Success = "Đăng nhập thành công";
                    return Redirect("/");
                }
                else
                {
                    ViewBag.Error = "Tài khoản hoặc mật khẩu không chính xác.";
                }

            }

            return View(model);
        }
        public ActionResult Logout()
        {
            Session[Common.CommonConstants.USER_SESSION_CUSTOM] = null;
            return Redirect("/");
        }
    }
}