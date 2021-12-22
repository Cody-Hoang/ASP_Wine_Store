using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTL_ASP.NET_Nhom7.Areas.Admin.Data
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời nhập user name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Mời nhập pass word")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}