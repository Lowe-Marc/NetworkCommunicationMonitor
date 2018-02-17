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
    public class Card
    {

        public string cardNumber;

        public static List<Card> getCards()
        {
            List<Card> cards = new List<Card>();
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
                    card.cardNumber = (string)row["card_id"];
                    cards.Add(card);
                }
            }

            return cards;
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
    }

}