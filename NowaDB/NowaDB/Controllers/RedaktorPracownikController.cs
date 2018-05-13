using NowaDB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NowaDB.Controllers
{
    public class RedaktorPracownikController : Controller
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