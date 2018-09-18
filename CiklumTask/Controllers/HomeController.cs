using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CiklumTask.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Title = "About";
            ViewBag.Message = "Application description";

            return View("About");
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "Contact";
            ViewBag.Message = "Contact page";

            return View("Contact");
        }
    }
}