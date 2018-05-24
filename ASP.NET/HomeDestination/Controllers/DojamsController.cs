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
    public class DojamsController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: Dojams
        public ActionResult Index()
        {
            return View(db.Dojam.ToList());
        }

        // GET: Dojams/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dojam dojam = db.Dojam.Find(id);
            if (dojam == null)
            {
                return HttpNotFound();
            }
            return View(dojam);
        }

        // GET: Dojams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dojams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SmjestajId,KorisnikId,Ocjena,Komentar")] Dojam dojam)
        {
            if (ModelState.IsValid)
            {
                db.Dojam.Add(dojam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dojam);
        }

        // GET: Dojams/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dojam dojam = db.Dojam.Find(id);
            if (dojam == null)
            {
                return HttpNotFound();
            }
            return View(dojam);
        }

        // POST: Dojams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SmjestajId,KorisnikId,Ocjena,Komentar")] Dojam dojam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dojam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dojam);
        }

        // GET: Dojams/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dojam dojam = db.Dojam.Find(id);
            if (dojam == null)
            {
                return HttpNotFound();
            }
            return View(dojam);
        }

        // POST: Dojams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Dojam dojam = db.Dojam.Find(id);
            db.Dojam.Remove(dojam);
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
