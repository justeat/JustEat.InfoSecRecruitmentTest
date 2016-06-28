using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InfoSecTechTest.Models;
using System.Web.Security;
using InfoSecTechTest.DAL;
using System.Text;

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

        public ActionResult ChangePassword()
        {
            HttpCookie UserCookie = Request.Cookies.Get("UserSettings");
            var user = Server.UrlDecode(UserCookie["user"]);

            if(user == null)
            {
                RedirectToAction("Index", "Articles");
            }

            byte[] bytes = Convert.FromBase64String(user);
            String username = Encoding.UTF8.GetString(bytes);
            
            User u = db.Users.Where(ua => ua.Username == username).FirstOrDefault();

            if (u == null)
            {
                RedirectToAction("Index", "Articles");
            }

            return View(u);

        }

        [HttpPost]
        public ActionResult ChangePassword(User u)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Form is not valid; please review and try again.";
                return View();
            }
            db.Users.Attach(u);
            db.Entry(u).Property(x => x.Password).IsModified = true;
            db.SaveChanges();

            ViewBag.Error = "Saved";
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
                byte[] bytesToEncode = Encoding.UTF8.GetBytes(login.Username);

                HttpCookie UserCookie = new HttpCookie("UserSettings");
                UserCookie["user"] = Server.UrlEncode(Convert.ToBase64String(bytesToEncode));
                Response.Cookies.Add(UserCookie);
            }

            ViewBag.Error = "Credentials invalid. Please try again.";
            return View("Login");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Response.Cookies.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Articles");
        }


    }
}