﻿using System;
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
            if (Session["username"] == null)
                return RedirectToAction("Index","Home");
            ViewData["NumAccounts"] = NetworkCommunicationMonitor.Models.Account.getNumAccounts();
            ViewData["NumCards"] = NetworkCommunicationMonitor.Models.Card.getNumCards();
            ViewData["NumStores"] = NetworkCommunicationMonitor.Models.Store.getNumStores();
            ViewData["NumRelays"] = NetworkCommunicationMonitor.Models.Relay.getNumRelays();
            ViewData["NumTransactions"] = NetworkCommunicationMonitor.Models.Transaction.getNumTransactions();
            return View();
        }

        public ActionResult Account()
        {
            if (Session["username"] == null)
                return RedirectToAction("Index", "Home");
            ViewData["NumAccounts"] = NetworkCommunicationMonitor.Models.Account.getNumAccounts();
            ViewData["NumCards"] = NetworkCommunicationMonitor.Models.Card.getNumCards();
            ViewData["NumStores"] = NetworkCommunicationMonitor.Models.Store.getNumStores();
            ViewData["NumRelays"] = NetworkCommunicationMonitor.Models.Relay.getNumRelays();
            ViewData["NumTransactions"] = NetworkCommunicationMonitor.Models.Transaction.getNumTransactions();
            ViewData["Accounts"] = NetworkCommunicationMonitor.Models.Account.getAccounts();
            return View();
        }

        public ActionResult Card()
        {
            if (Session["username"] == null)
                return RedirectToAction("Index", "Home");
            ViewData["NumAccounts"] = NetworkCommunicationMonitor.Models.Account.getNumAccounts();
            ViewData["NumCards"] = NetworkCommunicationMonitor.Models.Card.getNumCards();
            ViewData["NumStores"] = NetworkCommunicationMonitor.Models.Store.getNumStores();
            ViewData["NumRelays"] = NetworkCommunicationMonitor.Models.Relay.getNumRelays();
            ViewData["NumTransactions"] = NetworkCommunicationMonitor.Models.Transaction.getNumTransactions();
            ViewData["Cards"] = NetworkCommunicationMonitor.Models.Card.getCards();
            ViewData["Accounts"] = NetworkCommunicationMonitor.Models.Account.getAccounts();
            return View();
        }

        public ActionResult Station()
        {
            if (Session["username"] == null)
                return RedirectToAction("Index", "Home");
            ViewData["NumAccounts"] = NetworkCommunicationMonitor.Models.Account.getNumAccounts();
            ViewData["NumCards"] = NetworkCommunicationMonitor.Models.Card.getNumCards();
            ViewData["NumStores"] = NetworkCommunicationMonitor.Models.Store.getNumStores();
            ViewData["NumRelays"] = NetworkCommunicationMonitor.Models.Relay.getNumRelays();
            ViewData["NumTransactions"] = NetworkCommunicationMonitor.Models.Transaction.getNumTransactions();
            ViewData["Relays"] = NetworkCommunicationMonitor.Models.Relay.getRelays();
            return View();
        }

        public ActionResult Transaction()
        {
            if (Session["username"] == null)
                return RedirectToAction("Index", "Home");
            ViewData["NumAccounts"] = NetworkCommunicationMonitor.Models.Account.getNumAccounts();
            ViewData["NumCards"] = NetworkCommunicationMonitor.Models.Card.getNumCards();
            ViewData["NumStores"] = NetworkCommunicationMonitor.Models.Store.getNumStores();
            ViewData["NumRelays"] = NetworkCommunicationMonitor.Models.Relay.getNumRelays();
            ViewData["NumTransactions"] = NetworkCommunicationMonitor.Models.Transaction.getNumTransactions();
            ViewData["Transactions"] = NetworkCommunicationMonitor.Models.Transaction.getTransactions();
            return View();
        }

        public ActionResult Store()
        {
            if (Session["username"] == null)
                return RedirectToAction("Index", "Home");
            ViewData["NumAccounts"] = NetworkCommunicationMonitor.Models.Account.getNumAccounts();
            ViewData["NumCards"] = NetworkCommunicationMonitor.Models.Card.getNumCards();
            ViewData["NumStores"] = NetworkCommunicationMonitor.Models.Store.getNumStores();
            ViewData["NumRelays"] = NetworkCommunicationMonitor.Models.Relay.getNumRelays();
            ViewData["NumTransactions"] = NetworkCommunicationMonitor.Models.Transaction.getNumTransactions();
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

        public ActionResult AddAccount(FormCollection collection)
        {
            ViewData["NumAccounts"] = NetworkCommunicationMonitor.Models.Account.getNumAccounts();
            ViewData["NumCards"] = NetworkCommunicationMonitor.Models.Card.getNumCards();
            ViewData["NumStores"] = NetworkCommunicationMonitor.Models.Store.getNumStores();
            ViewData["NumRelays"] = NetworkCommunicationMonitor.Models.Relay.getNumRelays();
            ViewData["NumTransactions"] = NetworkCommunicationMonitor.Models.Transaction.getNumTransactions();

            string firstName = Convert.ToString(collection["firstname"]);
            string lastName = Convert.ToString(collection["lastname"]);
            string address = Convert.ToString(collection["address"]);
            string phone = Convert.ToString(collection["input2"]);
            phone = phone.Remove(9, 1);
            phone = phone.Remove(5, 1);
            phone = phone.Remove(4, 1);
            phone = phone.Remove(0, 1);
            int limit = Convert.ToInt32(collection["limit"]);
            double balance = Convert.ToDouble(collection["balance"]);
            NetworkCommunicationMonitor.Models.Account.createAccount(firstName, lastName, address, phone, limit, balance);

            int accountID = NetworkCommunicationMonitor.Models.Account.getAccountID(firstName, lastName, address, phone, limit, balance);
            string cardNumber = Convert.ToString(collection["number"]);
            cardNumber = cardNumber.Remove(14, 1);
            cardNumber = cardNumber.Remove(9, 1);
            cardNumber = cardNumber.Remove(4, 1);
            string fullName = Convert.ToString(collection["name"]);
            string[] names = fullName.Split(' ');
            string cardFirstName = names[0];
            string cardLastName = names[1];
            DateTime expiry = Convert.ToDateTime(collection["expiry"]);
            int month = expiry.Month;
            int year = expiry.Year;
            string cvc = Convert.ToString(collection["cvc"]);
            NetworkCommunicationMonitor.Models.Card.createCard(cardNumber, cardFirstName, cardLastName, month, year, accountID, cvc);

            return RedirectToAction("Account", "Home");
        }

        public ActionResult DeleteAccount(FormCollection collection)
        {
            ViewData["NumAccounts"] = NetworkCommunicationMonitor.Models.Account.getNumAccounts();
            ViewData["NumCards"] = NetworkCommunicationMonitor.Models.Card.getNumCards();
            ViewData["NumStores"] = NetworkCommunicationMonitor.Models.Store.getNumStores();
            ViewData["NumRelays"] = NetworkCommunicationMonitor.Models.Relay.getNumRelays();
            ViewData["NumTransactions"] = NetworkCommunicationMonitor.Models.Transaction.getNumTransactions();

            NetworkCommunicationMonitor.Models.Account.deleteAccount(Convert.ToInt32(collection["accountID"]));

            return RedirectToAction("Account", "Home");
        }

        public ActionResult EditAccount(FormCollection collection)
        {
            ViewData["NumAccounts"] = NetworkCommunicationMonitor.Models.Account.getNumAccounts();
            ViewData["NumCards"] = NetworkCommunicationMonitor.Models.Card.getNumCards();
            ViewData["NumStores"] = NetworkCommunicationMonitor.Models.Store.getNumStores();
            ViewData["NumRelays"] = NetworkCommunicationMonitor.Models.Relay.getNumRelays();
            ViewData["NumTransactions"] = NetworkCommunicationMonitor.Models.Transaction.getNumTransactions();

            int accountID = Convert.ToInt32(collection["accountID"]);
            string firstName = Convert.ToString(collection["firstName"]);
            string lastName = Convert.ToString(collection["lastName"]);
            string address = Convert.ToString(collection["address"]);
            string phone = Convert.ToString(collection["input2"]);
            NetworkCommunicationMonitor.Models.Account.editAccount(accountID, firstName, lastName, address, phone);

            return RedirectToAction("Account", "Home");
        }

        public ActionResult AddCard(FormCollection collection)
        {
            ViewData["NumAccounts"] = NetworkCommunicationMonitor.Models.Account.getNumAccounts();
            ViewData["NumCards"] = NetworkCommunicationMonitor.Models.Card.getNumCards();
            ViewData["NumStores"] = NetworkCommunicationMonitor.Models.Store.getNumStores();
            ViewData["NumRelays"] = NetworkCommunicationMonitor.Models.Relay.getNumRelays();
            ViewData["NumTransactions"] = NetworkCommunicationMonitor.Models.Transaction.getNumTransactions();

            string cardNumber = Convert.ToString(collection["number"]);
            cardNumber = cardNumber.Remove(14, 1);
            cardNumber = cardNumber.Remove(9, 1);
            cardNumber = cardNumber.Remove(4, 1);
            string fullName = Convert.ToString(collection["name"]);
            string[] names = fullName.Split(' ');
            string cardFirstName = names[0];
            string cardLastName = names[1];
            string exp = Convert.ToString(collection["expiry"]);
            exp = exp.Remove(4, 1);
            exp = exp.Remove(2, 1);
            //DateTime expiry = DateTime.ParseExact(exp,"mm/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
            //int month = expiry.Month;
            //int year = expiry.Year;
            int month = Convert.ToInt32(exp.Substring(0, 2));
            int year = Convert.ToInt32(exp.Substring(3, 4));
            string cvc = Convert.ToString(collection["cvc"]);
            int accountID = Convert.ToInt32(collection["accountID"]);
            NetworkCommunicationMonitor.Models.Card.createCard(cardNumber, cardFirstName, cardLastName, month, year, accountID, cvc);

            return RedirectToAction("Card", "Home");
        }

        public ActionResult DeleteCard(FormCollection collection)
        {
            ViewData["NumAccounts"] = NetworkCommunicationMonitor.Models.Account.getNumAccounts();
            ViewData["NumCards"] = NetworkCommunicationMonitor.Models.Card.getNumCards();
            ViewData["NumStores"] = NetworkCommunicationMonitor.Models.Store.getNumStores();
            ViewData["NumRelays"] = NetworkCommunicationMonitor.Models.Relay.getNumRelays();
            ViewData["NumTransactions"] = NetworkCommunicationMonitor.Models.Transaction.getNumTransactions();

            NetworkCommunicationMonitor.Models.Card.deleteCard(Convert.ToString(collection["delete_cardNumber"]));

            return RedirectToAction("Card", "Home");
        }

        public ActionResult EditCard(FormCollection collection)
        {
            ViewData["NumAccounts"] = NetworkCommunicationMonitor.Models.Account.getNumAccounts();
            ViewData["NumCards"] = NetworkCommunicationMonitor.Models.Card.getNumCards();
            ViewData["NumStores"] = NetworkCommunicationMonitor.Models.Store.getNumStores();
            ViewData["NumRelays"] = NetworkCommunicationMonitor.Models.Relay.getNumRelays();
            ViewData["NumTransactions"] = NetworkCommunicationMonitor.Models.Transaction.getNumTransactions();

            string firstName = Convert.ToString(collection["firstName"]);
            string lastName = Convert.ToString(collection["lastName"]);
            string cardNumber = Convert.ToString(collection["cardNumber"]);

            NetworkCommunicationMonitor.Models.Card.editCard(firstName, lastName, cardNumber);

            return RedirectToAction("Card", "Home");
        }
    }
}