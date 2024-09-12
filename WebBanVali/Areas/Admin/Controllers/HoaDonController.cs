using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanVali.Models;

namespace WebBanVali.Areas.Admin.Controllers
{
    public class HoaDonController : Controller
    {
        private QLBanVaLiEntities db = new QLBanVaLiEntities();

        // GET: Admin/HoaDon
        public ActionResult Index()
        {
            var tHoaDonBans = db.tHoaDonBans.Include(t => t.tKhachHang);
            return View(tHoaDonBans.ToList());
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
