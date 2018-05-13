using NowaDB.Controllers;
using NowaDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Net.Controllers
{
    public class HomeController : Controller
    {
        //private Database1Entities db = new Database1Entities();

        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View();
        }


        [Authorize(Roles = "Sekretarz")]
        public ActionResult SekretarzSite()
        {
            return View();
        }
        [Authorize(Roles = "Redaktor")]
        public ActionResult RedaktorSite()
        {
            //return Redirect("admin/Index");
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User model, string returnUrl)
        {
        Database1Entities1 db = new Database1Entities1();
        var dataItem = db.User.Where(x => x.Username == model.Username && x.Password == model.Password).First();
            if (dataItem != null)
            {
                FormsAuthentication.SetAuthCookie(dataItem.Username, false);
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                         && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    if (dataItem.Role == "Administrator")
                    {
                        return RedirectToAction("Index");
                    }
                    else if (dataItem.Role == "Redaktor")
                    {
                        return RedirectToAction("RedaktorSite");
                    }
                    else
                    {
                        return RedirectToAction("SekretarzSite");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid user/pass");
                return View();
            }
        }
        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");

        }
    }
}