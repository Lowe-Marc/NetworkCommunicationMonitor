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
            Session["user"] = null;
            Session["username"] = null;
            Session["adminID"] = null;
            NetworkCommunicationMonitor.Models.Global.questionIDs = new int[3];
            NetworkCommunicationMonitor.Models.Global.questions = new Stack<string>();
            NetworkCommunicationMonitor.Models.Global.correctAnswers = new Stack<string>();
            return View();
        }

        public ActionResult Homepage()
        {
            ViewData["NumAccounts"] = NetworkCommunicationMonitor.Models.Account.getNumAccounts();
            ViewData["NumCards"] = NetworkCommunicationMonitor.Models.Card.getNumCards();
            ViewData["NumStores"] = NetworkCommunicationMonitor.Models.Store.getNumStores();
            ViewData["NumRelays"] = NetworkCommunicationMonitor.Models.Relay.getNumRelays();
            return View();
        }

        public ActionResult Account()
        {
            ViewData["Accounts"] = NetworkCommunicationMonitor.Models.Account.getAccounts();
            return View();
        }

        public ActionResult Card()
        {
            ViewData["Cards"] = NetworkCommunicationMonitor.Models.Card.getCards();
            return View();
        }

        public ActionResult Station()
        {
            ViewData["Relays"] = NetworkCommunicationMonitor.Models.Relay.getRelays();
            return View();
        }

        public ActionResult Store()
        {
            ViewData["Stores"] = NetworkCommunicationMonitor.Models.Store.getStores();
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
            Session["username"] = null;
            Session["adminID"] = null;
            NetworkCommunicationMonitor.Models.Global.questionIDs = new int[3];
            NetworkCommunicationMonitor.Models.Global.questions = new Stack<string>();
            NetworkCommunicationMonitor.Models.Global.correctAnswers = new Stack<string>();
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