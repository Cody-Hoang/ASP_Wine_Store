using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTL_ASP.NET_Nhom7.Models;
namespace BTL_ASP.NET_Nhom7.DAO
{
    public class CatalogyDao
    {
        WineStoreDB db = null;
        public CatalogyDao()
        {
            db = new WineStoreDB();
        }
        public List<Catalogy> ListAll()
        {
            return db.Catalogy.ToList();
        }

        public Catalogy ViewDetail(long id)
        {
            return db.Catalogy.Find(id);
        }
    }
}