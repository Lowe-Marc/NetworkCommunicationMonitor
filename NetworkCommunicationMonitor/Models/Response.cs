using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Net.Mail;
using System.Web.UI;

namespace NetworkCommunicationMonitor.Models
{
    public class Response
    {
        public int id;
        public int transactionId;
        public string storeId;
        public DateTime date;
        public bool status;

        public Response()
        {

        }

        public static Response generateResponse(Transaction transaction)
        {
            Response response = new Response();
            Account account = Card.getAccountForCard(transaction.cardID);

            response.transactionId = transaction.transactionID;
            response.storeId = transaction.storeID;
            response.date = transaction.transactionDate;

            if ((account.accountBalance + transaction.amount > account.accountLimit) && transaction.category.Equals("Credit"))
            {
                denyTransaction(transaction);
                response.status = true;
            }
            else
            {
                approveTransaction(transaction, account);
                response.status = false;
            }

            return response;
        }

        private static void approveTransaction(Transaction transaction, Account account)
        {
            Account.chargeAccount(transaction, account.accountBalance, account.accountNumber);
            Transaction.approveTransaction(transaction);
        }

        private static void denyTransaction(Transaction transaction)
        {
            // Transactions are by default not approved
        }
    }
}