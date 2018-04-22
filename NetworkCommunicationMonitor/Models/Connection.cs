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
    public class Connection
    {
        public int id;
        public string ipOne;
        public string source;
        public string ipTwo;
        public string target;
        public int distance;
        public int value;
        public int weight;

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
                string _sql = @"SELECT connection_id, station_one_id, station_two_id, weight FROM Connection";
                var cmd = new SqlCommand(_sql, cn);

                cn.Open();

                questionTable.Load(cmd.ExecuteReader());
                rows = questionTable.Rows;

                foreach (DataRow row in rows)
                {
                    Connection tempConnection = new Connection();
                    tempConnection.id = Convert.ToInt32(row["connection_id"]);
                    tempConnection.ipOne = Convert.ToString(row["station_one_id"]);
                    tempConnection.source = Convert.ToString(row["station_one_id"]);
                    tempConnection.ipTwo = Convert.ToString(row["station_two_id"]);
                    tempConnection.target = Convert.ToString(row["station_two_id"]);
                    tempConnection.distance = Convert.ToInt32(row["weight"]);
                    tempConnection.value = 4;
                    connections.Add(tempConnection);
                }
            }

            return connections;
        }


        public static string addConnection(int weight, string ipOne, string ipTwo)
        {
            string result = "";

            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            var cn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            var cn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            var cn3 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            var cn4 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            var cn5 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            var cn6 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            var cn7 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            var cn8 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            var cn9 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            var cn10 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            string region1;
            string region2;
            int amount1, amount2;
            bool isGateway1, isGateway2;
            int amount3, amount4;

            if (ipOne != ipTwo)
            {
                using (cn9)
                {
                    string _sql9 = @"SELECT Count(station_one_id) From Connection WHERE station_one_id = '"+ipOne+"' AND station_two_id = '"+ipTwo+"'";
                    var cmd9 = new SqlCommand(_sql9, cn9);
                    cn9.Open();
                    amount3 = (int)cmd9.ExecuteScalar();
                }
                using (cn10)
                {
                    string _sql10 = @"SELECT Count(station_one_id) From Connection WHERE station_one_id = '" + ipTwo + "' AND station_two_id = '" + ipOne + "'";
                    var cmd10 = new SqlCommand(_sql10, cn10);
                    cn10.Open();
                    amount4 = (int)cmd10.ExecuteScalar();
                }

                if(amount3 == 1 || amount4 == 1)
                {
                    result = "This connection already exists";
                }
                else
                {

                using (cn1)
                {
                    string _sql1 = @"SELECT Count(store_id) FROM Store WHERE store_id = '" + ipOne + "'";
                    var cmd1 = new SqlCommand(_sql1, cn1);
                    cn1.Open();
                    amount1 = (int)cmd1.ExecuteScalar();
                    if (amount1 == 1)
                    {
                        using (cn2)
                        {
                            string _sql2 = @"SELECT region FROM Store WHERE store_id = '" + ipOne + "'";
                            var cmd2 = new SqlCommand(_sql2, cn2);
                            cn2.Open();
                            region1 = (string)cmd2.ExecuteScalar();
                        }
                    }
                    else
                    {
                        using (cn3)
                        {
                            string _sql3 = @"SELECT region FROM RelayStation WHERE station_id = '" + ipOne + "'";
                            var cmd3 = new SqlCommand(_sql3, cn3);
                            cn3.Open();
                            region1 = (string)cmd3.ExecuteScalar();
                        }
                    }
                }

                using (cn4)
                {
                    string _sql4 = @"SELECT Count(store_id) FROM Store WHERE store_id = '" + ipTwo + "'";
                    var cmd4 = new SqlCommand(_sql4, cn4);
                    cn4.Open();
                    amount2 = (int)cmd4.ExecuteScalar();
                    if (amount2 == 1)
                    {
                        using (cn5)
                        {
                            string _sql5 = @"SELECT region FROM Store WHERE store_id = '" + ipTwo + "'";
                            var cmd5 = new SqlCommand(_sql5, cn5);
                            cn5.Open();
                            region2 = (string)cmd5.ExecuteScalar();
                        }
                    }

                    else
                    {
                        using (cn6)
                        {
                            string _sql6 = @"SELECT region FROM RelayStation WHERE station_id = '" + ipTwo + "'";
                            var cmd6 = new SqlCommand(_sql6, cn6);
                            cn6.Open();
                            region2 = (string)cmd6.ExecuteScalar();
                        }

                    }
                }

                if (amount1 != 1)
                {
                    using (cn7)
                    {
                        string _sql7 = @"SELECT isGateway FROM RelayStation WHERE station_id = '" + ipOne + "'";
                        var cmd7 = new SqlCommand(_sql7, cn7);
                        cn7.Open();
                        isGateway1 = (bool)cmd7.ExecuteScalar();
                    }
                }
                else
                {
                    isGateway1 = false;
                }

                if (amount2 != 1)
                {
                    using (cn8)
                    {
                        string _sql8 = @"SELECT isGateway FROM RelayStation WHERE station_id = '" + ipTwo + "'";
                        var cmd8 = new SqlCommand(_sql8, cn8);
                        cn8.Open();
                        isGateway2 = (bool)cmd8.ExecuteScalar();
                    }
                }
                else
                {
                    isGateway2 = false;
                }


                if (region1 == region2 || (isGateway1 == true && isGateway2 == true))
                {
                    if (amount1 == 1 && amount2 == 1)
                    {
                        Console.WriteLine("Store cannot be connected to store!");
                        result = "Store cannot be connected to store!";
                    }
                    else
                    {

                        using (cn)
                        {
                            string _sql = @"INSERT INTO Connection (station_one_id, station_two_id, connection_isActive, weight) VALUES('" + ipOne + "', '" + ipTwo + "', '" + 1 + "', '" + weight + "')";
                            var cmd = new SqlCommand(_sql, cn);


                            cn.Open();
                            cmd.ExecuteNonQuery();
                            cn.Close();

                        }
                        result = "Connection added successfully!";
                    }
                }
                else
                {
                    Console.WriteLine("It cannot be connected to relaystation or store in other region!");
                    result = "Only gateways may make connection across regions.";
                }

                }
            }
            else
            {
                Console.WriteLine("It cannot be connected to itself!");
                result = "A store/relay cannot be connected to itself.";
            }

            return result;
        }
    }
}
