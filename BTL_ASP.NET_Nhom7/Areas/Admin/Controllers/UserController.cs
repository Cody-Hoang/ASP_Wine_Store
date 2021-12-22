using BTL_ASP.NET_Nhom7.DAO;
using BTL_ASP.NET_Nhom7.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_ASP.NET_Nhom7.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        WineStoreDB db = new WineStoreDB();
        public ActionResult Index(int? page)
        {
            var user = db.User.Select(s => s);
            user = user.OrderBy(s => s.UserId);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(user.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            List<SelectListItem> ddl = new List<SelectListItem>();
            var res = db.GroupUsers.Select(x => x).ToList();
            foreach (var item in res)
                ddl.Add(new SelectListItem()
                {
                    Text = item.GroupName,
                    Value = item.GroupId.ToString(),

                });
            ViewBag.GroupId = ddl;
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            if(ModelState.IsValid)
            {

                var dao = new UserDAO();
                long id = dao.Insert(user);
                if(id > 0)
                {
                    return RedirectToAction("Index","User");
                }
            }
            else
            {
                ModelState.AddModelError("", "Add user successfully!");
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            List<SelectListItem> ddl = new List<SelectListItem>();
            var res = db.GroupUsers.Select(x => x).ToList();
            foreach (var item in res)
                ddl.Add(new SelectListItem()
                {
                    Text = item.GroupName,
                    Value = item.GroupId.ToString(),

                });
            ViewBag.GroupId = ddl;
            var user = new UserDAO().VieweDetails(id);
            return View(user);
;        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {

                var dao = new UserDAO();
                bool res = dao.Update(user);
                if (res )
                {
                    return RedirectToAction("Index", "User");
                }
            }
            else
            {
                ModelState.AddModelError("", "Update user successfully!");
            }
            return View("Index");
        }
    }
}