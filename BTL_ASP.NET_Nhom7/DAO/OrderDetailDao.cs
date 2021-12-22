using BTL_ASP.NET_Nhom7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_ASP.NET_Nhom7.DAO
{
    public class OrderDetailDao
    {
        WineStoreDB db = null;
        public OrderDetailDao()
        {
            db = new WineStoreDB();
        }
        public bool Insert(OrderDetails detail)
        {
            try
            {
                db.OrderDetails.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;

            }
        }
    }
}