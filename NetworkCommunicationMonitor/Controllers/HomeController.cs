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

        public ActionResult Homepage()
        {
            return View();
        }

        public ActionResult Account()
        {
            ViewData["Accounts"] = NetworkCommunicationMonitor.Models.Account.getAccounts();
            return View();
        }

        public ActionResult Card()
        {
            return View();
        }

        public ActionResult Station()
        {
            return View();
        }

        public ActionResult Store()
        {
            return View();
        }

        public ActionResult Pages404()
        {
            return View();
        }

        public ActionResult Pages500()
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