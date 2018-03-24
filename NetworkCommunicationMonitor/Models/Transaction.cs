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
    public class Transaction
    {

        public string transactionID;
        public int accountID;
        public string storeID;
        public DateTime transactionDate;
        public double amount;
        public string category;
        public string responseID;
        public DateTime statusTime;
        public bool status;
        public bool encrypted;

        public Transaction()
        {

        }

        // Static query to the database that returns a list of these models for every account
        public static List<Transaction> getTransactions()
        {
            List<Transaction> transactions = new List<Transaction>();

            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (cn)
            {
                DataTable questionTable = new DataTable();
                DataRowCollection rows;
                string _sql = @"SELECT trans_id, account_id, store_id, trans_date, trans_amount, trans_category, trans_status, response_id, status_time, encrypted FROM Transactions";
                var cmd = new SqlCommand(_sql, cn);

                cn.Open();

                questionTable.Load(cmd.ExecuteReader());
                rows = questionTable.Rows;

                foreach (DataRow row in rows)
                {
                    Transaction tempTransaction = new Transaction();
                    tempTransaction.transactionID = Convert.ToString(row["trans_id"]);
                    tempTransaction.accountID = Convert.ToInt32(row["account_id"]);
                    tempTransaction.storeID = Convert.ToString(row["store_id"]);
                    tempTransaction.transactionDate = Convert.ToDateTime(row["trans_date"]);
                    tempTransaction.amount = Convert.ToDouble(row["trans_amount"]);
                    tempTransaction.category = Convert.ToString(row["trans_category"]);
                    tempTransaction.responseID = Convert.ToString(row["response_id"]);
                    tempTransaction.statusTime = Convert.ToDateTime(row["status_time"]);
                    tempTransaction.status = Convert.ToBoolean(row["trans_status"]);
                    tempTransaction.encrypted = Convert.ToBoolean(row["encrypted"]);
                    transactions.Add(tempTransaction);
                }
            }

            return transactions;
        }

        // Static query to the database that returns the count of these models in the database
        public static int getNumTransactions()
        {
            int numTransactions = 0;

            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (cn)
            {
                DataTable questionTable = new DataTable();
                DataRowCollection rows;
                string _sql = @"SELECT Count(*) FROM Transactions";
                var cmd = new SqlCommand(_sql, cn);

                cn.Open();

                questionTable.Load(cmd.ExecuteReader());
                rows = questionTable.Rows;

                foreach (DataRow row in rows)
                {
                    numTransactions = Convert.ToInt32(row[0]);
                }
            }

            return numTransactions;
        }

        public static void addTransaction(int accountNumber, string storeIP)
        {
            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (cn)
            {

                DateTime transactionDate = new DateTime(2018, 1, 1);
                double transactionAmount = 0.0;
                string transactionCategory = "Credit";
                int transactionStatus = 0;
                string responseID = "-1";
                DateTime statusTime = new DateTime(2018, 1, 1);
                int encrypted = 0;

                string _sql = @"INSERT INTO Transactions (account_id, store_id, trans_date, trans_amount, trans_category, trans_status, response_id, status_time, encrypted) VALUES("
                    + "@AccountNumber, @StoreIP, @TransactionDate, @TransactionAmount, @TransactionCategory, @TransactionStatus, @ResponseID, @StatusTime, @Encrypted)";

                var cmd = new SqlCommand(_sql, cn);
                cmd.Parameters.Add("@AccountNumber", SqlDbType.Int).Value = accountNumber;
                cmd.Parameters.Add("@StoreIP", SqlDbType.VarChar).Value = storeIP;
                cmd.Parameters.Add("@TransactionDate", SqlDbType.DateTime).Value = transactionDate;
                cmd.Parameters.Add("@TransactionAmount", SqlDbType.Float).Value = transactionAmount;
                cmd.Parameters.Add("@TransactionCategory", SqlDbType.VarChar).Value = transactionCategory;
                cmd.Parameters.Add("@TransactionStatus", SqlDbType.Bit).Value = transactionStatus;
                cmd.Parameters.Add("@ResponseID", SqlDbType.VarChar).Value = responseID;
                cmd.Parameters.Add("@StatusTime", SqlDbType.DateTime).Value = statusTime;
                cmd.Parameters.Add("@Encrypted", SqlDbType.Bit).Value = encrypted;

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
    }
}