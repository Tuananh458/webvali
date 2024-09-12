using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanVali.Models;

namespace WebBanVali.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            Cart cart = Session["Cart"] as Cart ?? new Cart();
            ViewBag.CartItemCount = cart.Count;
            return View(cart);
        }
        [HttpGet]
        public ActionResult AddToCart(int maSanPham, int count)
        {
            Cart cart = Session["Cart"] as Cart ?? new Cart();
            cart.AddCart(maSanPham, count);
            Session["Cart"] = cart;
            return RedirectToAction("Index");
        }
        public int GetCount()
        {
            Cart cart = Session["Cart"] as Cart ?? new Cart();
            int count = cart.Count;
            return count;
        }
        public int GetSum()
        {
            Cart cart = Session["Cart"] as Cart ?? new Cart();
            int sum = cart.Sum;
            return sum;
        }

        [HttpPost]
        public ActionResult UpdateCartItem(int maSanPham, int newQuantity)
        {
            Cart cart = Session["Cart"] as Cart ?? new Cart();
            cart.AddCart(maSanPham, newQuantity);
            Session["Cart"] = cart;
            var hangHet = cart.HangHet();
            if (!string.IsNullOrEmpty(hangHet))
            {
                return Json(new { success = false, hangHet = hangHet });
            }

            Session["Cart"] = cart;

            return Json(new { success = true });
        }
        [HttpPost]
        public ActionResult RemoveCartItem()
        {
            return Json(new { success = true });
        }
        [HttpPost]
        public ActionResult UpdateCart()
        {
            Cart cart = new Cart();
            Session["Cart"] = cart;
            return Json(new { success = true });
        }
    }
}