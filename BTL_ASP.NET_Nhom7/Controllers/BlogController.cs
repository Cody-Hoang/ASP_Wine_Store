using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_ASP.NET_Nhom7.Models;
using PagedList;
namespace BTL_ASP.NET_Nhom7.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        WineStoreDB db = new WineStoreDB();
        public ActionResult Index(int? page)
        {
            var listBlog = db.Blog.OrderBy(x => x.CreateDate);
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(listBlog.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Details(int BlogId)
        {
            var blog = db.Blog.Where(x => x.BlogId == BlogId).SingleOrDefault();
            return View(blog);
        }
    }
}