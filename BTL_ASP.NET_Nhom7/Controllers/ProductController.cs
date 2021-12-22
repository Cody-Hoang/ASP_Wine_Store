using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_ASP.NET_Nhom7.Models;
using BTL_ASP.NET_Nhom7.DAO;
using PagedList;
namespace BTL_ASP.NET_Nhom7.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        WineStoreDB db = null;
        public ActionResult Index()
        {
            var productDao = new ProductDao();
            ViewBag.NewProduct = productDao.ListNewProduct(4);
            ViewBag.ListHotsell = productDao.ListHotSell(4);
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult ProductCatalogy()
        {
            db = new WineStoreDB();
            var model = db.Catalogy.ToList();
            return PartialView(model);
        }
        public ActionResult Details(long id)
        {
            var product = new ProductDao().ViewDetail(id);
            ViewBag.catalogy = new CatalogyDao().ViewDetail(product.CatalogyId);
            ViewBag.RelatedProducts = new ProductDao().ListRelatedProducts(id);
            return View(product);
        }
        public ActionResult Catalogy(long cataId, int? page)
        {
            var catalogy = new CatalogyDao().ViewDetail(cataId);
            ViewBag.catalogy = catalogy;
            var model = new ProductDao().ListByCatalogyId(cataId);
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(model.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult ListAllProducts(int? page)
        {
            db = new WineStoreDB();
            var listAllProducts = db.Product.OrderBy(x=>x.CreateDate);
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(listAllProducts.ToPagedList(pageNumber, pageSize));
        }
        [HttpPost]
        public ActionResult FindProductsByName(string searchString)
        {
            db = new WineStoreDB();
            ViewBag.findProductsByName = db.Product.Where(x => x.ProductName.Contains(searchString)).ToList();
            ViewBag.searchString = searchString;
            return View();
        }
        public ActionResult Find(string price_range, string volume)
        {
            db = new WineStoreDB();
            var product = new List<Product>();
            if(price_range != null )
            {
                decimal price = Convert.ToDecimal(price_range);
                if(price == 500000)
                {
                    product = db.Product.Where(x => x.PurchasePrice < price).ToList();
                }    
                else if(price == 1000000)
                {
                    product = db.Product.Where(x => x.PurchasePrice < price && x.PurchasePrice >= 500000).ToList();
                }
                else if(price == 3000000)
                {
                    product = db.Product.Where(x => x.PurchasePrice < price && x.PurchasePrice >= 1000000).ToList();
                }
                else
                {
                    product = db.Product.Where(x => x.PurchasePrice >= price-1).ToList();
                }
            }  
            if(volume != null)
            {
                    int vol = Convert.ToInt32(volume);
                if(product.Count > 0)
                {
                    product = product.Where(x => x.Capacity == vol).ToList();
                }    
                else
                {
                    product = db.Product.Where(x => x.Capacity == vol).ToList();
                }    
            }
    
            ViewBag.find = product;
            return View("FindProductsByName");
        }
    }
}