using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_ASP.NET_Nhom7.Models
{
    public class HotSell
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal PurchasePrice { get; set; }
        public int TotalQuantity { get; set; }
    }
}