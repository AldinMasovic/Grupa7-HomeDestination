using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeDestination.Models;

namespace HomeDestination.Controllers
{
    public class SmjestajsController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: Smjestajs
        public ActionResult Index()
        {
            return View(db.Smjestaj.ToList());
        }

        // GET: Smjestajs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smjestaj smjestaj = db.Smjestaj.Find(id);
            if (smjestaj == null)
            {
                return HttpNotFound();
            }
            return View(smjestaj);
        }

        // GET: Smjestajs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Smjestajs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Vrsta,Cijena,Kvadratura,Lokacija,PogododnoStudentima,Opis,BrojCimera,Datum")] Smjestaj smjestaj)
        {
            if (ModelState.IsValid)
            {
                db.Smjestaj.Add(smjestaj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(smjestaj);
        }

        // GET: Smjestajs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smjestaj smjestaj = db.Smjestaj.Find(id);
            if (smjestaj == null)
            {
                return HttpNotFound();
            }
            return View(smjestaj);
        }

        // POST: Smjestajs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Vrsta,Cijena,Kvadratura,Lokacija,PogododnoStudentima,Opis,BrojCimera,Datum")] Smjestaj smjestaj)
        {
            if (ModelState.IsValid)
            {
                db.Entry(smjestaj).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(smjestaj);
        }

        // GET: Smjestajs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smjestaj smjestaj = db.Smjestaj.Find(id);
            if (smjestaj == null)
            {
                return HttpNotFound();
            }
            return View(smjestaj);
        }

        // POST: Smjestajs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Smjestaj smjestaj = db.Smjestaj.Find(id);
            db.Smjestaj.Remove(smjestaj);
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
