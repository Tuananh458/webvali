using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebBanVali.Models;
namespace WebBanVali.Controllers
{
    public class AccountController : Controller
    {
        QLBanVaLiEntities entity = new QLBanVaLiEntities();
        public ActionResult Login()
        {
            return View();
        }
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel credentials)
        {
            bool userExist = entity.tKhachHangs.Any(x => x.username == credentials.Username && x.MatKhau == credentials.Password);
            tKhachHang u = entity.tKhachHangs.FirstOrDefault(x => x.username == credentials.Username && x.MatKhau == credentials.Password);
            Session["Customer"] = u;

            if (userExist)
            {
                FormsAuthentication.SetAuthCookie(u.username, false);
                return RedirectToAction("LoadGrid", "Product");
            }
            else if ("admin" == credentials.Username && "1234" == credentials.Password)
            {
                FormsAuthentication.SetAuthCookie("Xin Chào Admin", false);
                return RedirectToAction("AdminHome", "Admin");
            }
            ModelState.AddModelError("", "Username or password is wrong");

            return View();
        }
        [HttpPost]
        public ActionResult Register(tKhachHang info)
        {
            entity.tKhachHangs.Add(info);
            Session["Customer"] = info;
            entity.SaveChanges();
            return RedirectToAction("Login");
        }
        public ActionResult Signout()
        {
            Session["Customer"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("LoadGrid", "Product");
        }
    }
}