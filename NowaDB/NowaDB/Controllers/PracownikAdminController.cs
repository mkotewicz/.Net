using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NowaDB.Models;

namespace NowaDB.Controllers
{
    public class PracownikAdminController : Controller
    {
        private Database1Entities1 db = new Database1Entities1();

        // GET: PracownikAdmin
        public ActionResult Index()
        {
            var pracownik = db.Pracownik.Include(p => p.Adres);
            return View(pracownik.ToList());
        }

        // GET: PracownikAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pracownik pracownik = db.Pracownik.Find(id);
            if (pracownik == null)
            {
                return HttpNotFound();
            }
            return View(pracownik);
        }

        // GET: PracownikAdmin/Create
        public ActionResult Create()
        {
            ViewBag.adresId = new SelectList(db.Adres, "Id", "ulica");
            return View();
        }

        // POST: PracownikAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,imie,nazwisko,pesel,email,telefon,adresId")] Pracownik pracownik)
        {
            if (ModelState.IsValid)
            {
                db.Pracownik.Add(pracownik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.adresId = new SelectList(db.Adres, "Id", "ulica", pracownik.adresId);
            return View(pracownik);
        }

        // GET: PracownikAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pracownik pracownik = db.Pracownik.Find(id);
            if (pracownik == null)
            {
                return HttpNotFound();
            }
            ViewBag.adresId = new SelectList(db.Adres, "Id", "ulica", pracownik.adresId);
            return View(pracownik);
        }

        // POST: PracownikAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,imie,nazwisko,pesel,email,telefon,adresId")] Pracownik pracownik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pracownik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.adresId = new SelectList(db.Adres, "Id", "ulica", pracownik.adresId);
            return View(pracownik);
        }

        // GET: PracownikAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pracownik pracownik = db.Pracownik.Find(id);
            if (pracownik == null)
            {
                return HttpNotFound();
            }
            return View(pracownik);
        }

        // POST: PracownikAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pracownik pracownik = db.Pracownik.Find(id);
            db.Pracownik.Remove(pracownik);
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
