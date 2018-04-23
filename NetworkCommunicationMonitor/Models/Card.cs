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
    public class Card
    {

        public string cardNumber;
        public string firstName;
        public string lastName;
        public int expirationMonth;
        public int expirationYear;
        public string accountNumber;

        public static List<Card> getCards()
        {
            List<Card> cards = new List<Card>();

            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (cn)
            {
                DataTable questionTable = new DataTable();
                DataRowCollection rows;
                string _sql = @"SELECT card_id, card_firstname, card_lastname, card_expirationMonth, card_expirationYear, account_id FROM Card";
                var cmd = new SqlCommand(_sql, cn);

                cn.Open();

                questionTable.Load(cmd.ExecuteReader());
                rows = questionTable.Rows;

                foreach (DataRow row in rows)
                {
                    Card tempCard = new Card();
                    tempCard.cardNumber = formatCardNumber(Convert.ToString(row["card_id"]));
                    tempCard.firstName = Convert.ToString(row["card_firstname"]);
                    tempCard.lastName = Convert.ToString(row["card_lastname"]);
                    tempCard.expirationMonth = Convert.ToInt32(row["card_expirationMonth"]);
                    tempCard.expirationYear = Convert.ToInt32(row["card_expirationYear"]);
                    tempCard.accountNumber = Convert.ToString(row["account_id"]);
                    cards.Add(tempCard);
                }
            }

            return cards;
        }

        // Static query get the number of cards
        public static List<Card> getCardsForAccount(int accountID)
        {
            List<Card> cards = new List<Card>();

            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (cn)
            {
                DataTable questionTable = new DataTable();
                DataRowCollection rows;
                string _sql = @"SELECT card_id FROM Card WHERE account_id = " + accountID;
                var cmd = new SqlCommand(_sql, cn);

                cn.Open();

                questionTable.Load(cmd.ExecuteReader());
                rows = questionTable.Rows;

                foreach (DataRow row in rows)
                {
                    Card card = new Card();
                    card.cardNumber = formatCardNumber((string)row["card_id"]);
                    cards.Add(card);
                }
            }

            return cards;
        }

        // This will take the card number and put a space every 4 numbers for readability
        public static string formatCardNumber(string cardNumber)
        {
            string formattedNumber = "";
            for (int i = 0; i < cardNumber.Length; i++)
            {
                if (i % 4 == 0 && i > 0)
                {
                    formattedNumber = formattedNumber + " ";
                }
                formattedNumber = formattedNumber + cardNumber[i];
            }
            return formattedNumber;
        }

        // Static query get the number of cards
        public static int getNumCards()
        {
            int numCards = 0;

            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (cn)
            {
                DataTable questionTable = new DataTable();
                DataRowCollection rows;
                string _sql = @"SELECT Count(*) FROM Card";
                var cmd = new SqlCommand(_sql, cn);

                cn.Open();

                questionTable.Load(cmd.ExecuteReader());
                rows = questionTable.Rows;

                foreach (DataRow row in rows)
                {
                    numCards = Convert.ToInt32(row[0]);
                }
            }

            return numCards;
        }

        public static string deleteCard(string cardID)
        {
            string result = "Card " + cardID + " successfully deleted";

            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            var cn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            var cn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            var cn3 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            string accountID;
            int amount;

            using (cn3)
            {
                string _sql3 = @"SELECT COUNT(card_id) FROM Card WHERE card_id = '" + cardID + "'";
                var cmd3 = new SqlCommand(_sql3, cn3);
                cn3.Open();
                amount = (int)cmd3.ExecuteScalar();

            }

            if (amount != 1)
            {
                result = "Card " + cardID + " does not exist";
            }

            else
            {
                using (cn2)
                {
                    string _sql2 = @"SELECT DISTINCT account_id FROM Card WHERE card_id = '" + cardID + "'";
                    var cmd2 = new SqlCommand(_sql2, cn2);
                    cn2.Open();
                    SqlDataReader sdr = cmd2.ExecuteReader();
                    sdr.Close();
                    accountID = Convert.ToString(cmd2.ExecuteScalar());
                    cn2.Close();
                }
                using (cn1)
                {
                    string _sql1 = @"SELECT COUNT(account_id) FROM Card WHERE account_id = '" + accountID + "'";
                    var cmd1 = new SqlCommand(_sql1, cn1);
                    cn1.Open();
                    amount = (int)cmd1.ExecuteScalar();

                    if (amount != 1)
                    {
                        using (cn)
                        {
                            string _sql = @"DELETE FROM Card WHERE card_id = '" + cardID + "'";
                            var cmd = new SqlCommand(_sql, cn);

                            cn.Open();
                            cmd.ExecuteNonQuery();
                            cn.Close();
                        }
                    }
                    else
                    {
                        result = "The last card " + cardID + " of an account " + accountID + " cannot be deleted!";
                    }
                }
            }
          
            return result;
        }

        public static void deleteCardsForAccount(int accountID)
        {
            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (cn)
            {
                string _sql = @"DELETE FROM Card WHERE account_id = " + accountID;
                var cmd = new SqlCommand(_sql, cn);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        public static string createCard(string cardID, string firstname, string lastname, int card_expirationMonth, int card_expirationYear, int accountID, string cvc)
        {
            string result = "";
            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            var cn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            int amount;
            using (cn1)
            {
                string _sql1 = @"SELECT COUNT(card_id) FROM Card WHERE card_id = '" + cardID + "'";
                var cmd1 = new SqlCommand(_sql1, cn1);
                cn1.Open();
                amount = (int)cmd1.ExecuteScalar();
            }

            if (amount == 1)
            {
                result = "This card already exists!";
            }
            else
            {
                using (cn)
                {
                    string _sql = @"INSERT INTO Card (card_id, card_firstname, card_lastname, card_expirationMonth, "
                    + "card_expirationYear, card_securityCode, account_id) VALUES('" + cardID + "', '" + firstname + "', '" + lastname + "', "
                    + card_expirationMonth + ", " + card_expirationYear + ", " + cvc + ", " + accountID + ")";
                    var cmd = new SqlCommand(_sql, cn);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                result = "Card added successfully";
            }
            return result;
        }


        public static void editCard(string firstname, string lastname, string cardID)
        {
            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (cn)
            {
                string _sql = @"UPDATE Card SET card_firstname = '" + firstname + "', card_lastname = '" + lastname + "' WHERE card_id = " + cardID;
                var cmd = new SqlCommand(_sql, cn);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        public static Account getAccountForCard(string cardNumber)
        {
            int accountNumber = 0;

            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (cn)
            {
                DataTable questionTable = new DataTable();
                DataRowCollection rows;
                string _sql = @"SELECT account_id FROM Card WHERE card_id = @CardNumber";
                var cmd = new SqlCommand(_sql, cn);

                cmd.Parameters.Add("@CardNumber", SqlDbType.VarChar).Value = cardNumber;

                cn.Open();

                questionTable.Load(cmd.ExecuteReader());
                rows = questionTable.Rows;

                accountNumber = Convert.ToInt32(rows[0]["account_id"]);
            }

            Account account = Account.getAccountByNumber(accountNumber);

            return account;
        }
    }

}
