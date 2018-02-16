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
    public class Account
    {
        public string firstName;
        public string lastName;
        public string cardNumber;
        public string accountAddress;
        public string phoneNumber;
        public int accountLimit;
        public double accountBalance;

        public Account()
        {

        }

        // Static query to the database that returns a list of these models for every account
        public static List<Account> getAccounts()
        {
            List<Account> accounts = new List<Account>();
            
            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (cn)
            {
                DataTable questionTable = new DataTable();
                DataRowCollection rows;
                string _sql = @"SELECT card_id, account_holder_firstname, account_holder_lastname, account_address, account_phone, account_limit, account_balance FROM Account";
                var cmd = new SqlCommand(_sql, cn);

                cn.Open();

                questionTable.Load(cmd.ExecuteReader());
                rows = questionTable.Rows;

                foreach (DataRow row in rows )
                {
                    Account tempAccount = new Account();
                    tempAccount.cardNumber = (string)row["card_id"];
                    tempAccount.firstName = (string)row["account_holder_firstname"];
                    tempAccount.lastName = (string)row["account_holder_lastname"];
                    tempAccount.accountAddress = (string)row["account_address"];
                    tempAccount.phoneNumber = (string)row["account_phone"];
                    tempAccount.accountLimit = Convert.ToInt32(row["account_limit"]);
                    tempAccount.accountBalance = Convert.ToDouble(row["account_balance"]);
                    accounts.Add(tempAccount);
                }
            }

            return accounts;
        }
    }
}