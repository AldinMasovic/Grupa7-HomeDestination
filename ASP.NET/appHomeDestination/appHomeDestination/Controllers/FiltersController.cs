using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using appHomeDestination.Models;

namespace appHomeDestination.Controllers
{
    public class FiltersController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: Filters
        public ActionResult Index()
        {
            return View(db.Filter.ToList());
        }

        // GET: Filters/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filter filter = db.Filter.Find(id);
            if (filter == null)
            {
                return HttpNotFound();
            }
            return View(filter);
        }

        // GET: Filters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Filters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Namjestaj,Parking,WiFi,Lift,Klima,Balkon,Novogradnja,Alarm,Videonadzor,TV")] Filter filter)
        {
            if (ModelState.IsValid)
            {
                db.Filter.Add(filter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(filter);
        }

        // GET: Filters/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filter filter = db.Filter.Find(id);
            if (filter == null)
            {
                return HttpNotFound();
            }
            return View(filter);
        }

        // POST: Filters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Namjestaj,Parking,WiFi,Lift,Klima,Balkon,Novogradnja,Alarm,Videonadzor,TV")] Filter filter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(filter);
        }

        // GET: Filters/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filter filter = db.Filter.Find(id);
            if (filter == null)
            {
                return HttpNotFound();
            }
            return View(filter);
        }

        // POST: Filters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Filter filter = db.Filter.Find(id);
            db.Filter.Remove(filter);
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
