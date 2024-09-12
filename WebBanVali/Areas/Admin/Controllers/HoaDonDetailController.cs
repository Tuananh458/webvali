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
    public class HoaDonDetailController : Controller
    {
        private QLBanVaLiEntities db = new QLBanVaLiEntities();

        // GET: Admin/HoaDonDetail
        public ActionResult Index(int? MaHoaDon)
        {
            IQueryable<tChiTietHDB> tChiTietHDBs;
            // Lọc danh sách chi tiết hóa đơn theo MaHoaDon
            if (MaHoaDon != null)
                tChiTietHDBs = db.tChiTietHDBs
                    .Include(t => t.tChiTietSanPham)
                    .Include(t => t.tHoaDonBan)
                    .Where(t => t.MaHoaDon == MaHoaDon);
            else
                tChiTietHDBs = db.tChiTietHDBs
                    .Include(t => t.tChiTietSanPham)
                    .Include(t => t.tHoaDonBan);


            return View(tChiTietHDBs.ToList());
        }

        // GET: Admin/HoaDonDetail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tChiTietHDB tChiTietHDB = db.tChiTietHDBs.Find(id);
            if (tChiTietHDB == null)
            {
                return HttpNotFound();
            }
            return View(tChiTietHDB);
        }

        // GET: Admin/HoaDonDetail/Create
        public ActionResult Create()
        {
            ViewBag.MaChiTietSP = new SelectList(db.tChiTietSanPhams, "MaChiTietSP", "TenChiTietSP");
            ViewBag.MaHoaDon = new SelectList(db.tHoaDonBans, "MaHoaDon", "Name");
            return View();
        }

        // POST: Admin/HoaDonDetail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaChiTietHDB,MaHoaDon,MaChiTietSP,SoLuong,DonGia")] tChiTietHDB tChiTietHDB)
        {
            if (ModelState.IsValid)
            {
                db.tChiTietHDBs.Add(tChiTietHDB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaChiTietSP = new SelectList(db.tChiTietSanPhams, "MaChiTietSP", "TenChiTietSP", tChiTietHDB.MaChiTietSP);
            ViewBag.MaHoaDon = new SelectList(db.tHoaDonBans, "MaHoaDon", "Name", tChiTietHDB.MaHoaDon);
            return View(tChiTietHDB);
        }

        // GET: Admin/HoaDonDetail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tChiTietHDB tChiTietHDB = db.tChiTietHDBs.Find(id);
            if (tChiTietHDB == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaChiTietSP = new SelectList(db.tChiTietSanPhams, "MaChiTietSP", "TenChiTietSP", tChiTietHDB.MaChiTietSP);
            ViewBag.MaHoaDon = new SelectList(db.tHoaDonBans, "MaHoaDon", "Name", tChiTietHDB.MaHoaDon);
            return View(tChiTietHDB);
        }

        // POST: Admin/HoaDonDetail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaChiTietHDB,MaHoaDon,MaChiTietSP,SoLuong,DonGia")] tChiTietHDB tChiTietHDB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tChiTietHDB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaChiTietSP = new SelectList(db.tChiTietSanPhams, "MaChiTietSP", "TenChiTietSP", tChiTietHDB.MaChiTietSP);
            ViewBag.MaHoaDon = new SelectList(db.tHoaDonBans, "MaHoaDon", "Name", tChiTietHDB.MaHoaDon);
            return View(tChiTietHDB);
        }

        // GET: Admin/HoaDonDetail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tChiTietHDB tChiTietHDB = db.tChiTietHDBs.Find(id);
            if (tChiTietHDB == null)
            {
                return HttpNotFound();
            }
            return View(tChiTietHDB);
        }

        // POST: Admin/HoaDonDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tChiTietHDB tChiTietHDB = db.tChiTietHDBs.Find(id);
            db.tChiTietHDBs.Remove(tChiTietHDB);
            db.SaveChanges();
            return RedirectToAction("Index");
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
