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
using System.Windows.Forms;

namespace NetworkCommunicationMonitor.Models
{
    public class Account
    {
        public string firstName;
        public string lastName;
        public int accountNumber;
        public string accountAddress;
        public string phoneNumber;
        public int accountLimit;
        public double accountBalance;
        public List<Card> cards;


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
                string _sql = @"SELECT account_id, account_holder_firstname, account_holder_lastname, account_address, account_phone, account_limit, account_balance FROM Account";
                var cmd = new SqlCommand(_sql, cn);

                cn.Open();

                questionTable.Load(cmd.ExecuteReader());
                rows = questionTable.Rows;

                foreach (DataRow row in rows )
                {
                    Account tempAccount = new Account();
                    int accountNumber = Convert.ToInt32(row["account_id"]);
                    tempAccount.accountNumber = accountNumber;
                    tempAccount.cards = Card.getCardsForAccount(accountNumber);
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

        // Static query to the database that returns a list of these models for every account
        public static int getNumAccounts()
        {
            int numAccounts = 0;

            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (cn)
            {
                DataTable questionTable = new DataTable();
                DataRowCollection rows;
                string _sql = @"SELECT Count(*) FROM Account";
                var cmd = new SqlCommand(_sql, cn);

                cn.Open();

                questionTable.Load(cmd.ExecuteReader());
                rows = questionTable.Rows;

                foreach (DataRow row in rows)
                {
                    numAccounts = Convert.ToInt32(row[0]);
                }
            }

            return numAccounts;
        }

        public static int getAccountID(string firstName, string lastName, string address, string phone, int limit, double balance)
        {
            int accountID = -1;

            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (cn)
            {
                DataTable questionTable = new DataTable();
                DataRowCollection rows;
                string _sql = @"SELECT account_id FROM Account WHERE account_holder_firstname = '" + firstName + "' AND account_holder_lastname = '" + lastName 
                    + "' AND account_address = '" + address + "' AND account_phone = '" + phone + "' AND account_limit = " + limit + " AND account_balance = " + balance;
                var cmd = new SqlCommand(_sql, cn);

                cn.Open();

                questionTable.Load(cmd.ExecuteReader());
                rows = questionTable.Rows;

                foreach (DataRow row in rows)
                {
                    accountID = Convert.ToInt32(row["account_id"]);
                }
            }

            return accountID;
        }

        public static void deleteAccount(int accountID)
        {
            var cn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (cn1)
            {
                string _sql1 = @"SELECT account_balance FROM Account WHERE account_id = '" + accountID + "'";
                var cmd1 = new SqlCommand(_sql1, cn1);
                cn1.Open();
                double accountBalance = (double)cmd1.ExecuteScalar();

                if (accountBalance == 0)
                {
                    Card.deleteCardsForAccount(accountID);

                    var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    using (cn)
                    {
                        string _sql = @"DELETE FROM Account WHERE account_id = " + accountID;
                        var cmd = new SqlCommand(_sql, cn);

                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                    MessageBox.Show(" Account '" + accountID + "' deleted successfully! ");
                }
                else
                {
                    Console.WriteLine("This account cannot be deleted wiht non-zero balance!");
                    MessageBox.Show("This account cannot be deleted wiht non-zero balance!");
                }
            }

        }

        public static void createAccount(string firstname, string lastname, string address, string phone, int limit, double balance)
        {
            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (cn)
            {
                string _sql = @"INSERT INTO Account (account_holder_firstname, account_holder_lastname,
                account_address, account_phone, account_limit, account_balance) VALUES('" + firstname + "', '" + lastname + "', '" + address + "' , '" + phone + "', " + limit + ", " + balance + ")";
                var cmd = new SqlCommand(_sql, cn);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        public static void editAccount(int accountID, string firstname, string lastname, string address, string phone)
        {
            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (cn)
            {
                string _sql = @"UPDATE Account SET account_holder_firstname = '" + firstname + "',  account_holder_lastname = '" + lastname 
                    + "', account_address = '" + address + "', account_phone = '" + phone + "' WHERE account_id = " + accountID;
                var cmd = new SqlCommand(_sql, cn);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        public static Account getAccountByNumber(int accountNumber)
        {
            Account account = new Account();

            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (cn)
            {
                DataTable questionTable = new DataTable();
                DataRowCollection rows;
                string _sql = @"SELECT account_balance, account_limit FROM Account WHERE account_id = @AccountNumber";
                var cmd = new SqlCommand(_sql, cn);

                cmd.Parameters.Add("@AccountNumber", SqlDbType.Int).Value = accountNumber;

                cn.Open();

                questionTable.Load(cmd.ExecuteReader());
                rows = questionTable.Rows;

                account.accountNumber = accountNumber;
                account.accountLimit = Convert.ToInt32(rows[0]["account_limit"]);
                account.accountBalance = Convert.ToDouble(rows[0]["account_balance"]);
            }

            return account;
        }

        public static void chargeAccount(Transaction transaction, double balance, int accountNumber)
        {
            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (cn)
            {
                DataTable questionTable = new DataTable();
                string _sql = @"UPDATE Account SET account_balance = @AccountBalance WHERE account_id = @AccountNumber";
                var cmd = new SqlCommand(_sql, cn);

                if (transaction.category.Equals("Credit"))
                {
                    cmd.Parameters.Add("@AccountBalance", SqlDbType.Float).Value = balance + transaction.amount;
                } else
                {
                    cmd.Parameters.Add("@AccountBalance", SqlDbType.Float).Value = balance - transaction.amount;
                }
                
                cmd.Parameters.Add("@AccountNumber", SqlDbType.Int).Value = accountNumber;

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        public static string formatPhoneNumber(string phoneNumber)
        {
            string formattedNumber = "(";

            for (int i = 0; i < phoneNumber.Length; i++)
            {
                formattedNumber = formattedNumber + phoneNumber[i];
                if (i == 2)
                    formattedNumber = formattedNumber + ") ";
                else if (i == 5)
                    formattedNumber = formattedNumber + "-";
            }

            return formattedNumber;
        }
    }
}