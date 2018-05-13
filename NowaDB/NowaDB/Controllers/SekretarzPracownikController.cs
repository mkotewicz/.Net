using NowaDB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NowaDB.Controllers
{
    public class SekretarzPracownikController : Controller
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