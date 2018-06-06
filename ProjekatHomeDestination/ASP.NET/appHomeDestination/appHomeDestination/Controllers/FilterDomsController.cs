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
    public class FilterDomsController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: FilterDoms
        public ActionResult Index()
        {
            return View(db.Filter.ToList());
        }

        // GET: FilterDoms/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FilterDom filterDom =(FilterDom) db.Filter.Find(id);
            if (filterDom == null)
            {
                return HttpNotFound();
            }
            return View(filterDom);
        }

        // GET: FilterDoms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FilterDoms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Namjestaj,Parking,WiFi,Lift,Klima,Balkon,Novogradnja,Alarm,Videonadzor,TV,Teretana,Citaona,Kantina,VesMasina")] FilterDom filterDom)
        {
            if (ModelState.IsValid)
            {
                db.Filter.Add(filterDom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(filterDom);
        }

        // GET: FilterDoms/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FilterDom filterDom = (FilterDom)db.Filter.Find(id);
            if (filterDom == null)
            {
                return HttpNotFound();
            }
            return View(filterDom);
        }

        // POST: FilterDoms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Namjestaj,Parking,WiFi,Lift,Klima,Balkon,Novogradnja,Alarm,Videonadzor,TV,Teretana,Citaona,Kantina,VesMasina")] FilterDom filterDom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filterDom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(filterDom);
        }

        // GET: FilterDoms/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FilterDom filterDom = (FilterDom)db.Filter.Find(id);
            if (filterDom == null)
            {
                return HttpNotFound();
            }
            return View(filterDom);
        }

        // POST: FilterDoms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            FilterDom filterDom = (FilterDom)db.Filter.Find(id);
            db.Filter.Remove(filterDom);
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
