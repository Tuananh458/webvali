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
    public class CustomerController : Controller
    {
        private QLBanVaLiEntities db = new QLBanVaLiEntities();

        // GET: Admin/Customer
        public ActionResult Index()
        {
            return View(db.tKhachHangs.ToList());
        }

        // GET: Admin/Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tKhachHang tKhachHang = db.tKhachHangs.Find(id);
            if (tKhachHang == null)
            {
                return HttpNotFound();
            }
            return View(tKhachHang);
        }

        // GET: Admin/Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKhachHang,TenKhachHang,SoDienThoai,username,MatKhau")] tKhachHang tKhachHang)
        {
            if (ModelState.IsValid)
            {
                db.tKhachHangs.Add(tKhachHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tKhachHang);
        }

        // GET: Admin/Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tKhachHang tKhachHang = db.tKhachHangs.Find(id);
            if (tKhachHang == null)
            {
                return HttpNotFound();
            }
            return View(tKhachHang);
        }

        // POST: Admin/Customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKhachHang,TenKhachHang,SoDienThoai,username,MatKhau")] tKhachHang tKhachHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tKhachHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tKhachHang);
        }

        // GET: Admin/Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tKhachHang tKhachHang = db.tKhachHangs.Find(id);
            if (tKhachHang == null)
            {
                return HttpNotFound();
            }
            return View(tKhachHang);
        }

        // POST: Admin/Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tKhachHang tKhachHang = db.tKhachHangs.Find(id);
            db.tKhachHangs.Remove(tKhachHang);
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
