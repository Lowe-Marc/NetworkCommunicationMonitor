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
    public class Connection
    {
        public string ipOne;
        public string source;
        public string ipTwo;
        public string target;
        public int distance;
        public int value;

        public Connection()
        {

        }

        public static List<Connection> getConnectionsForMap()
        {
            List<Connection> connections = new List<Connection>();

            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (cn)
            {
                DataTable questionTable = new DataTable();
                DataRowCollection rows;
                string _sql = @"SELECT station_one_id, station_two_id FROM Connection";
                var cmd = new SqlCommand(_sql, cn);

                cn.Open();

                questionTable.Load(cmd.ExecuteReader());
                rows = questionTable.Rows;

                foreach (DataRow row in rows)
                {
                    Connection tempConnection = new Connection();
                    tempConnection.ipOne = Convert.ToString(row["station_one_id"]);
                    tempConnection.source = Convert.ToString(row["station_one_id"]);
                    tempConnection.ipTwo = Convert.ToString(row["station_two_id"]);
                    tempConnection.target = Convert.ToString(row["station_two_id"]);
                    tempConnection.distance = 100;
                    tempConnection.value = 4;
                    connections.Add(tempConnection);
                }
            }

            return connections;
        }

        public static void addConnection(string ipOne, string ipTwo)
        {
            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (cn)
            {
                string _sql = @"INSERT INTO Connection (station_one_id, station_two_id, connection_isActive, weight) VALUES('" + ipOne + "', '" + ipTwo + "', '" + 1 + "', '" + 1 + "')";
                var cmd = new SqlCommand(_sql, cn);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
    }
}