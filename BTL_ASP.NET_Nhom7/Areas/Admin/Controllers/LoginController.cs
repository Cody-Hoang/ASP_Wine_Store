using BTL_ASP.NET_Nhom7.Areas.Admin.Data;
using BTL_ASP.NET_Nhom7.Common;
using BTL_ASP.NET_Nhom7.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_ASP.NET_Nhom7.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                var dao = new UserDAO();
                var res = dao.Login(model.UserName, model.Password);
                if(res == 1)
                {
                    var user = dao.GetById(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserId = user.UserId;

                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");

                }
                else if (res == 0)
                {
                    ModelState.AddModelError("", "Incorrect Username or Password !");

                }

                else if (res == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa.");

                }
                else if (res == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng.");

                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng.");
                }



            }
            return View("Index");



        }
    }
}