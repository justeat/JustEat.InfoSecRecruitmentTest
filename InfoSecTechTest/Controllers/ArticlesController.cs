using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InfoSecTechTest.DAL;
using InfoSecTechTest.Models;

namespace InfoSecTechTest.Controllers
{
    public class ArticlesController : Controller
    {
        private SiteContext db = new SiteContext();

        // GET: Articles
        public ActionResult Index()
        {
            return View(db.Articles.ToList());
        }

        // GET: Articles/Details/5
        [ValidateInput(false)]
        public ActionResult Details(String id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.SqlQuery("SELECT * FROM dbo.Article WHERE ID=" + id).First<Article>();
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

       
    }
}
