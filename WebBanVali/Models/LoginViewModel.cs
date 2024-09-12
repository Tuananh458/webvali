using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebBanVali.Models
{
    public class LoginViewModel
    {
        [DisplayName("Tên đăng nhập")]
        public string Username { get; set; }
        [DisplayName("Mật khẩu")]
        public string Password { get; set; }
    }
}