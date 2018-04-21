using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NetworkCommunicationMonitor.Models;

namespace NetworkCommunicationMonitor.Controllers
{
    public class HomeController : Controller
    {
        private string startLocation;

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
            else
                Session["username"] = Session["username"];
            setViewDataDefaults();

            setNetworkData();
            ViewData["Cards"] = NetworkCommunicationMonitor.Models.Card.getCards();
            ViewData["TransactionStart"] = startLocation;

            return View();
        }

        public ActionResult Account()
        {
            if (Session["username"] == null)
                return RedirectToAction("Index", "Home");
            setViewDataDefaults();

            ViewData["Accounts"] = NetworkCommunicationMonitor.Models.Account.getAccounts();
            return View();
        }

        public ActionResult Card()
        {
            if (Session["username"] == null)
                return RedirectToAction("Index", "Home");
            setViewDataDefaults();

            ViewData["Cards"] = NetworkCommunicationMonitor.Models.Card.getCards();
            ViewData["Accounts"] = NetworkCommunicationMonitor.Models.Account.getAccounts();
            return View();
        }

        public ActionResult Station()
        {
            if (Session["username"] == null)
                return RedirectToAction("Index", "Home");
            setViewDataDefaults();

            ViewData["Relays"] = NetworkCommunicationMonitor.Models.Relay.getRelays();
            return View();
        }

        public ActionResult Transaction()
        {
            if (Session["username"] == null)
                return RedirectToAction("Index", "Home");
            setViewDataDefaults();

            ViewData["Transactions"] = NetworkCommunicationMonitor.Models.Transaction.getTransactions();
            return View();
        }

        public ActionResult Store()
        {
            if (Session["username"] == null)
                return RedirectToAction("Index", "Home");
            setViewDataDefaults();

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
            setViewDataDefaults();

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
            setViewDataDefaults();

            NetworkCommunicationMonitor.Models.Account.deleteAccount(Convert.ToInt32(collection["accountID"]));

            return RedirectToAction("Account", "Home");
        }

        public ActionResult EditAccount(FormCollection collection)
        {
            setViewDataDefaults();

            int accountID = Convert.ToInt32(collection["accountID"]);
            string firstName = Convert.ToString(collection["firstName"]);
            string lastName = Convert.ToString(collection["lastName"]);
            string address = Convert.ToString(collection["address"]);
            string phone = Convert.ToString(collection["phone"]);
            NetworkCommunicationMonitor.Models.Account.editAccount(accountID, firstName, lastName, address, phone);

            return RedirectToAction("Account", "Home");
        }

        public ActionResult AddCard(FormCollection collection)
        {
            setViewDataDefaults();

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
            setViewDataDefaults();

            NetworkCommunicationMonitor.Models.Card.deleteCard(Convert.ToString(collection["delete_cardNumber"]));

            return RedirectToAction("Card", "Home");
        }

        public ActionResult EditCard(FormCollection collection)
        {
            setViewDataDefaults();

            string firstName = Convert.ToString(collection["firstName"]);
            string lastName = Convert.ToString(collection["lastName"]);
            string cardNumber = Convert.ToString(collection["cardNumber"]);

            NetworkCommunicationMonitor.Models.Card.editCard(firstName, lastName, cardNumber);

            return RedirectToAction("Card", "Home");
        }

        public ActionResult AddRelay(FormCollection collection)
        {
            setViewDataDefaults();

            int weight = Convert.ToInt32(collection["relayWeight"]);
            string ipAddress = Convert.ToString(collection["relayIpAddress"]);
            string ipConnectedTo = Convert.ToString(collection["relayIpConnectedTo"]);

            string region = Relay.getRegion(ipConnectedTo);

            NetworkCommunicationMonitor.Models.Relay.addRelay(weight, ipAddress, ipConnectedTo, false, region, 10);

            return RedirectToAction("Homepage", "Home");
        }

        public ActionResult AddRegion(FormCollection collection)
        {
            setViewDataDefaults();

            int GRweight = Convert.ToInt32(collection["gateway-relay"]);
            int SRweight = Convert.ToInt32(collection["store-relay"]);
            string regionName = Convert.ToString(collection["region-name"]);
            string gatewayIPAddress = Convert.ToString(collection["gateway-ipAddress"]);
            string relayIPAddress = Convert.ToString(collection["relay-ipAddress"]);
            string storeIPAddress = Convert.ToString(collection["store-ipAddress"]);
            string storeName = Convert.ToString(collection["store-name"]);

            NetworkCommunicationMonitor.Models.Relay.addRegion(GRweight, SRweight, regionName, gatewayIPAddress, relayIPAddress, storeIPAddress, storeName);

            return RedirectToAction("Homepage", "Home");
        }

        public ActionResult AddStore(FormCollection collection)
        {
            setViewDataDefaults();
            
            int weight = Convert.ToInt32(collection["storeWeight"]);
            string storeName = Convert.ToString(collection["storeName"]);
            string ipAddress = Convert.ToString(collection["storeIpAddress"]);
            string ipConnectedTo = Convert.ToString(collection["storeIpConnectedTo"]);

            NetworkCommunicationMonitor.Models.Store.addStore(weight, ipAddress, ipConnectedTo, storeName);

            return RedirectToAction("Homepage", "Home");
        }

        public ActionResult AddConnection(FormCollection collection)
        {
            setViewDataDefaults();

            
            int weight = Convert.ToInt32(collection["connectionWeight"]);
            string ipOne = Convert.ToString(collection["ipOne"]);
            string ipTwo = Convert.ToString(collection["ipTwo"]);

            NetworkCommunicationMonitor.Models.Connection.addConnection(weight, ipOne, ipTwo);

            return RedirectToAction("Homepage", "Home");
        }

        public void ChangeQueueLimit(FormCollection collection)
        {
            String ipAddress = Convert.ToString(collection["ipAddress"]);
            int queueLimit = Convert.ToInt32(collection["queueLimit"]);

            NetworkCommunicationMonitor.Models.Relay.changeLimit(ipAddress, queueLimit);
        }

        public int AddTransaction(FormCollection collection)
        {
            setViewDataDefaults();
            setNetworkData();

            string storeIP = Convert.ToString(collection["storeIP"]);
            string card_number = Convert.ToString(collection["cardNumber"]);
            string cardNumber = card_number.Replace(" ", "");
            DateTime transactionDate = Convert.ToDateTime(collection["transactionDate"]);
            double transactionAmount = Convert.ToDouble(collection["amount"]);
            string transactionCategory = Convert.ToString(collection["category"]);
            bool transactionSelf = Convert.ToBoolean(collection["self"]);
            int id;

            Boolean isSuccessfully = NetworkCommunicationMonitor.Models.Transaction.addTransaction(cardNumber, storeIP, transactionDate, transactionAmount, transactionCategory, transactionSelf);
            if (isSuccessfully == true)
            {
                id = NetworkCommunicationMonitor.Models.Transaction.getTransactionID(cardNumber, storeIP, transactionDate, transactionAmount, transactionCategory, transactionSelf);

                return id;
            }
            else
            {
                id = -1;
                return id;
            }


        }

        public void GenerateResponse(FormCollection collection)
        {
            Transaction transaction = new Transaction();
            transaction.transactionID = Convert.ToInt32(collection["transactionID"]);
            transaction.cardID = Convert.ToString(collection["cardNumber"]).Replace(" ","");
            transaction.storeID = Convert.ToString(collection["storeIP"]);
            transaction.transactionDate = Convert.ToDateTime(collection["transactionDate"]);
            transaction.amount = Convert.ToDouble(collection["amount"]);
            transaction.category = Convert.ToString(collection["category"]);
            NetworkCommunicationMonitor.Models.Response.generateResponse(transaction);
        }

        private void setNetworkData()
        {
            List<Object> relays = Relay.getRelaysForMap();
            List<Object> stores = Models.Store.getStoresForMap();
            foreach (Models.Store store in stores)
            {
                relays.Add(store);
            }
            List<Connection> connections = Connection.getConnectionsForMap();

            ViewData["Nodes"] = relays;
            ViewData["Links"] = connections;
        }

        private void setViewDataDefaults()
        {
            ViewData["NumAccounts"] = NetworkCommunicationMonitor.Models.Account.getNumAccounts();
            ViewData["NumCards"] = NetworkCommunicationMonitor.Models.Card.getNumCards();
            ViewData["NumStores"] = NetworkCommunicationMonitor.Models.Store.getNumStores();
            ViewData["NumRelays"] = NetworkCommunicationMonitor.Models.Relay.getNumRelays();
            ViewData["NumTransactions"] = NetworkCommunicationMonitor.Models.Transaction.getNumTransactions();
        }
    }
}