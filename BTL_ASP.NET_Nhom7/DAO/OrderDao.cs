using BTL_ASP.NET_Nhom7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_ASP.NET_Nhom7.DAO
{
    public class OrderDao
    {
        WineStoreDB db = null;
        public OrderDao()
        {
            db = new WineStoreDB();
        }
        public long Insert(Order order)
        {
            db.Order.Add(order);
            db.SaveChanges();
            return order.OrderId;
        }
    }
}