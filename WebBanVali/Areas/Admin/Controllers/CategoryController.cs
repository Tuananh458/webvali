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
    public class CategoryController : Controller
    {
        private QLBanVaLiEntities db = new QLBanVaLiEntities();

        // GET: Admin/Category
        public ActionResult Index()
        {
            return View(db.tDanhMucSPs.ToList());
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tDanhMucSP tDanhMucSP = db.tDanhMucSPs.Find(id);
            if (tDanhMucSP == null)
            {
                return HttpNotFound();
            }
            return View(tDanhMucSP);
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDM,TenDM")] tDanhMucSP tDanhMucSP)
        {
            if (ModelState.IsValid)
            {
                db.tDanhMucSPs.Add(tDanhMucSP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tDanhMucSP);
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tDanhMucSP tDanhMucSP = db.tDanhMucSPs.Find(id);
            if (tDanhMucSP == null)
            {
                return HttpNotFound();
            }
            return View(tDanhMucSP);
        }

        // POST: Admin/Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDM,TenDM")] tDanhMucSP tDanhMucSP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tDanhMucSP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tDanhMucSP);
        }

        // GET: Admin/Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tDanhMucSP tDanhMucSP = db.tDanhMucSPs.Find(id);
            if (tDanhMucSP == null)
            {
                return HttpNotFound();
            }
            return View(tDanhMucSP);
        }

        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tDanhMucSP tDanhMucSP = db.tDanhMucSPs.Find(id);
            db.tDanhMucSPs.Remove(tDanhMucSP);
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
