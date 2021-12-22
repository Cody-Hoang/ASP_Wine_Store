using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTL_ASP.NET_Nhom7.Models;
namespace BTL_ASP.NET_Nhom7.DAO
{
    
    public class ProductDao
    {
        WineStoreDB db = null;
        public ProductDao()
        {
            db = new WineStoreDB();
        }
        public List<Product> ListNewProduct(int top)
        {
            return db.Product.OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }
        public List<Product> ListHotSell(int top)
        {
            List<Product> hotsell = (List<Product>)(from p in db.Product
                           let totalQuantity = (from od in db.OrderDetails
                                                join od2 in db.Order on od.OrderId equals od2.OrderId
                                                where od.ProductId == p.ProductId
                                                select od.Quantity).Sum()
                           where totalQuantity > 0
                           orderby totalQuantity descending
                           select p).Take(top).ToList();
            return hotsell;
        }
        public List<Product> ListAllProducts()
        {
            List<Product> listAll = db.Product.ToList();
            return listAll;
        }
        public Product ViewDetail(long id)
        {
            return db.Product.Find(id);
        }
        public List<Product> ListRelatedProducts(long productId)
        {
            var product = db.Product.Find(productId);
            return db.Product.Where(x => x.ProductId != productId && x.CatalogyId == product.CatalogyId).Take(4).ToList();
        }
        public List<Product> ListByCatalogyId(long catalogyId)
        {
            return db.Product.Where(x => x.CatalogyId == catalogyId).OrderBy(x=>x.CreateDate).ToList();
        }

    }
}