using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanVali.Models;

namespace WebBanVali.Areas.Admin.Controllers
{
    public class ValiController : Controller
    {
        private QLBanVaLiEntities db = new QLBanVaLiEntities();

        // GET: Admin/Product
        public ActionResult Index()
        {
            var tChiTietSanPhams = db.tChiTietSanPhams.Include(t => t.tDanhMucSP);
            return View(tChiTietSanPhams.ToList());
        }

        // GET: Admin/Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tChiTietSanPham tChiTietSanPham = db.tChiTietSanPhams.Find(id);
            if (tChiTietSanPham == null)
            {
                return HttpNotFound();
            }
            return View(tChiTietSanPham);
        }

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            ViewBag.MaDM = new SelectList(db.tDanhMucSPs, "MaDM", "TenDM");
            return View();
        }

        // POST: Admin/Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaChiTietSP,TenChiTietSP,MaDM,DonGiaBan,GiamGia,SLTon,KichThuoc,MauSac")] tChiTietSanPham tChiTietSanPham, HttpPostedFileBase AnhDaiDienFile)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra nếu có tệp tin được tải lên
                if (AnhDaiDienFile != null && AnhDaiDienFile.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(AnhDaiDienFile.FileName);
                    string path = Path.Combine(Server.MapPath("~/resources/img/product/"), fileName);
                    AnhDaiDienFile.SaveAs(path);

                    // Lưu đường dẫn vào cơ sở dữ liệu
                    tChiTietSanPham.AnhDaiDien = fileName;
                }

                // Tiếp tục lưu thông tin khác vào cơ sở dữ liệu
                db.tChiTietSanPhams.Add(tChiTietSanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDM = new SelectList(db.tDanhMucSPs, "MaDM", "TenDM", tChiTietSanPham.MaDM);
            return View(tChiTietSanPham);
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tChiTietSanPham tChiTietSanPham = db.tChiTietSanPhams.Find(id);
            if (tChiTietSanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDM = new SelectList(db.tDanhMucSPs, "MaDM", "TenDM", tChiTietSanPham.MaDM);
            return View(tChiTietSanPham);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaChiTietSP,TenChiTietSP,MaDM,DonGiaBan,GiamGia,SLTon,KichThuoc,MauSac,AnhDaiDien")] tChiTietSanPham tChiTietSanPham, HttpPostedFileBase AnhDaiDienFile)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra nếu có tệp tin được tải lên
                if (AnhDaiDienFile != null && AnhDaiDienFile.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(AnhDaiDienFile.FileName);
                    string path = Path.Combine(Server.MapPath("~/resources/img/product/"), fileName);
                    AnhDaiDienFile.SaveAs(path);

                    // Lưu đường dẫn vào cơ sở dữ liệu
                    tChiTietSanPham.AnhDaiDien = fileName;
                }

                // Cập nhật thông tin khác vào cơ sở dữ liệu
                db.Entry(tChiTietSanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDM = new SelectList(db.tDanhMucSPs, "MaDM", "TenDM", tChiTietSanPham.MaDM);
            return View(tChiTietSanPham);
        }

        // GET: Admin/Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tChiTietSanPham tChiTietSanPham = db.tChiTietSanPhams.Find(id);
            if (tChiTietSanPham == null)
            {
                return HttpNotFound();
            }
            return View(tChiTietSanPham);
        }

        // POST: Admin/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tChiTietSanPham tChiTietSanPham = db.tChiTietSanPhams.Find(id);
            db.tChiTietSanPhams.Remove(tChiTietSanPham);
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
