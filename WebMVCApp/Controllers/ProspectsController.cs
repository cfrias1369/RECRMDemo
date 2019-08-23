using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DBEntities;

namespace WebMVCApp.Controllers
{
    public class ProspectsController : Controller
    {
        private RECRMEntities db = new RECRMEntities();

        // GET: Prospects
        public ActionResult Index()
        {
            return View(db.Prospects.ToList());
        }

        // GET: Prospects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prospect prospect = db.Prospects.Find(id);
            if (prospect == null)
            {
                return HttpNotFound();
            }
            return View(prospect);
        }

        // GET: Prospects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prospects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,phoneNumber,InitialContactDate,initialContactNotes")] Prospect prospect)
        {
            if (ModelState.IsValid)
            {
                db.Prospects.Add(prospect);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prospect);
        }

        // GET: Prospects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prospect prospect = db.Prospects.Find(id);
            if (prospect == null)
            {
                return HttpNotFound();
            }
            return View(prospect);
        }

        // POST: Prospects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,phoneNumber,InitialContactDate,initialContactNotes")] Prospect prospect)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prospect).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prospect);
        }

        // GET: Prospects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prospect prospect = db.Prospects.Find(id);
            if (prospect == null)
            {
                return HttpNotFound();
            }
            return View(prospect);
        }

        // POST: Prospects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prospect prospect = db.Prospects.Find(id);
            db.Prospects.Remove(prospect);
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
