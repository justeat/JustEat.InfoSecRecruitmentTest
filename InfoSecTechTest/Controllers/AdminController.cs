using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InfoSecTechTest.Models;
using System.Web.Security;
using InfoSecTechTest.DAL;

namespace InfoSecTechTest.Controllers
{
    public class AdminController : Controller
    {
        private SiteContext db = new SiteContext();

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Form is not valid; please review and try again.";
                return View("Login");
            }

            User u = db.Users.Where(ua => ua.Username == login.Username && ua.Password == login.Password).FirstOrDefault();
            if (u!= null)
            {
                FormsAuthentication.RedirectFromLoginPage(login.Username, true);
            }

            ViewBag.Error = "Credentials invalid. Please try again.";
            return View("Login");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Articles");
        }


    }
}