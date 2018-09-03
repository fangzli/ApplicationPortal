using ApplicationPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApplicationPortal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        private ApplicationContext db = new ApplicationContext();

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            var applications = from m in db.Applications
                               select m;
            return View(applications);

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}