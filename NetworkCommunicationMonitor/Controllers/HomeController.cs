using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetworkCommunicationMonitor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session["user"] = null;
            Session["adminID"] = null;
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Blocked()
        {
            Session["user"] = null;
            return View();
        }
    }
}