using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanVali.Models;

namespace WebBanVali.Controllers
{
    public class PaymentController : Controller
    {
        private QLBanVaLiEntities db = new QLBanVaLiEntities();
        // GET: Payment
        // GET: Payment
        public ActionResult Index()
        {
            Cart cart = Session["Cart"] as Cart ?? new Cart();
            tKhachHang khachHang = Session["Customer"] as tKhachHang ?? db.tKhachHangs.Find(6);
            return View(new Order(cart, khachHang));
        }

        // POST: Payment/PlaceOrder
        public ActionResult PlaceOrder(String Name, String Address, String Phone, String Email, String Note)
        {
            Cart cart = Session["Cart"] as Cart ?? new Cart();
            tKhachHang khachHang = Session["Customer"] as tKhachHang ?? db.tKhachHangs.Find(6);
            Order order = new Order(cart, khachHang, Name, Address, Phone, Email, Note);
            order.PlaceOrder(); return RedirectToAction("LoadGrid", "Product");

        }

        // GET: Payment/ThankYou
        public ActionResult ThankYou()
        {
            // Display a thank you page after successful order placement
            return View();
        }
    }
}