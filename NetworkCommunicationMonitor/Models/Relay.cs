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
    public class Relay
    {

        public string ipAddress;
        public bool isActive;

        public static List<Relay> getRelays()
        {
            List<Relay> relays = new List<Relay>();

            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (cn)
            {
                DataTable questionTable = new DataTable();
                DataRowCollection rows;
                string _sql = @"SELECT station_id, station_isActive FROM RelayStation";
                var cmd = new SqlCommand(_sql, cn);

                cn.Open();

                questionTable.Load(cmd.ExecuteReader());
                rows = questionTable.Rows;

                foreach (DataRow row in rows)
                {
                    Relay tempRelay = new Relay();
                    tempRelay.ipAddress = Convert.ToString(row["station_id"]);
                    tempRelay.isActive = Convert.ToBoolean(row["station_isActive"]);
                    relays.Add(tempRelay);
                }
            }

            return relays;
        }

        public static int getNumRelays()
        {
            int numRelays = 0;

            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (cn)
            {
                DataTable questionTable = new DataTable();
                DataRowCollection rows;
                string _sql = @"SELECT Count(*) FROM RelayStation";
                var cmd = new SqlCommand(_sql, cn);

                cn.Open();

                questionTable.Load(cmd.ExecuteReader());
                rows = questionTable.Rows;

                foreach (DataRow row in rows)
                {
                    numRelays = Convert.ToInt32(row[0]);
                }
            }

            return numRelays;
        }
    }
}