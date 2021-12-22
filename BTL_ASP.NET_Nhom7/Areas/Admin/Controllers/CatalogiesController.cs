using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BTL_ASP.NET_Nhom7.Models;
using PagedList;

namespace BTL_ASP.NET_Nhom7.Areas.Admin.Controllers
{
    public class CatalogiesController : Controller
    {
        private WineStoreDB db = new WineStoreDB();

        // GET: Admin/Catalogies
        public ActionResult Index(int? page)
        {
            var catalogy = db.Catalogy.Select(c => c);
            catalogy = catalogy.OrderBy(c => c.CatalogyId);
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(catalogy.ToPagedList(pageNumber, pageSize));
        }



        // GET: Admin/Catalogies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalogy catalogy = db.Catalogy.Find(id);
            if (catalogy == null)
            {
                return HttpNotFound();
            }
            return View(catalogy);
        }

        // GET: Admin/Catalogies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Catalogies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CatalogyId,CatalogyName,Description,CreateDate,ModifiedDate,ParentId")] Catalogy catalogy)
        {
            if (ModelState.IsValid)
            {
                catalogy.CreateDate = DateTime.Now;
                catalogy.ModifiedDate = DateTime.Now;
                db.Catalogy.Add(catalogy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(catalogy);
        }

        // GET: Admin/Catalogies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalogy catalogy = db.Catalogy.Find(id);
            if (catalogy == null)
            {
                return HttpNotFound();
            }
            return View(catalogy);
        }

        // POST: Admin/Catalogies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CatalogyId,CatalogyName,Description,CreateDate,ModifiedDate,ParentId")] Catalogy catalogy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catalogy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(catalogy);
        }

        // GET: Admin/Catalogies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalogy catalogy = db.Catalogy.Find(id);
            if (catalogy == null)
            {
                return HttpNotFound();
            }
            return View(catalogy);
        }

        // POST: Admin/Catalogies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Catalogy catalogy = db.Catalogy.Find(id);
            db.Catalogy.Remove(catalogy);
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
