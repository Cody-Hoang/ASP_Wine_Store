using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_ASP.NET_Nhom7.Common
{
        [Serializable]
    public class UserLogin
    {

        public long UserId { set; get; }
        public string UserName { set; get; }
        public string GroupID { set; get; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

    }
}