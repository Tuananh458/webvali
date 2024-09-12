using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanVali.Models;

namespace WebBanVali.Controllers
{
    public class ProductController : Controller
    {
        IPagedList<tChiTietSanPham> res;
        // GET: Product
        [HttpGet]
        public ActionResult Index(int product_id)
        {
            ListProduct ls = Session["ListProduct"] as ListProduct ?? new ListProduct();
            return View(ls.getProduct(product_id));
        }
        public ActionResult LoadGrid()
        {
            return View();
        }
        public ActionResult Reload()
        {
            ListProduct ls = new ListProduct();
            Session["ListProduct"] = ls;
            return View("listProduct", ls.getListProduct(1));
        }
        public ActionResult listProduct(int? page, int? categoryId, double? minPrice, double? maxPrice, string color, string size, string productName)
        {
            ListProduct ls = Session["ListProduct"] as ListProduct ?? new ListProduct();
            res = ls.getListProduct(page ?? 1, categoryId, minPrice, maxPrice, color, size, productName);
            Session["ListProduct"] = ls;
            return View(res);
        }
        public ActionResult listProduct2(int? page, int? categoryId, double? minPrice, double? maxPrice, string color, string size, string productName)
        {
            ListProduct ls = Session["ListProduct"] as ListProduct ?? new ListProduct();
            res = ls.getListProduct(page ?? 1, categoryId, minPrice, maxPrice, color, size, productName);
            Session["ListProduct"] = ls;
            return View("LoadGrid",res);
        }
    }
}