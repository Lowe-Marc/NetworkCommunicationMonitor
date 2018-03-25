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
        public string id;
        public bool isActive;
        public bool isGateway;
        public string region;
        public int group;

        public static readonly int RELAYGROUP = 2;
        public static readonly int PROCESSINGCENTERGROUP = 0;
        public static readonly string PROCESSINGCENTERIP = "192.168.0.1";

        public static List<Relay> getRelays()
        {
            List<Relay> relays = new List<Relay>();

            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (cn)
            {
                DataTable questionTable = new DataTable();
                DataRowCollection rows;
                string _sql = @"SELECT station_id, station_isActive, isGateway, region FROM RelayStation";
                var cmd = new SqlCommand(_sql, cn);

                cn.Open();

                questionTable.Load(cmd.ExecuteReader());
                rows = questionTable.Rows;

                foreach (DataRow row in rows)
                {
                    Relay tempRelay = new Relay();
                    tempRelay.ipAddress = Convert.ToString(row["station_id"]);
                    tempRelay.id = Convert.ToString(row["station_id"]);
                    tempRelay.region = Convert.ToString(row["region"]);
                    tempRelay.isActive = Convert.ToBoolean(row["station_isActive"]);
                    tempRelay.isGateway = Convert.ToBoolean(row["isGateway"]);
                    if (tempRelay.id.Equals("192.168.0.1", StringComparison.Ordinal))
                    {
                        tempRelay.group = PROCESSINGCENTERGROUP;
                    }
                    else
                    {
                        tempRelay.group = RELAYGROUP;
                    }
                    relays.Add(tempRelay);
                }
            }

            return relays;
        }

        public static List<Object> getRelaysForMap()
        {
            List<Object> relays = new List<Object>();

            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (cn)
            {
                DataTable questionTable = new DataTable();
                DataRowCollection rows;
                string _sql = @"SELECT station_id, station_isActive, isGateway, region FROM RelayStation";
                var cmd = new SqlCommand(_sql, cn);

                cn.Open();

                questionTable.Load(cmd.ExecuteReader());
                rows = questionTable.Rows;

                foreach (DataRow row in rows)
                {
                    Relay tempRelay = new Relay();
                    tempRelay.ipAddress = Convert.ToString(row["station_id"]);
                    tempRelay.id = Convert.ToString(row["station_id"]);
                    tempRelay.region = Convert.ToString(row["region"]);
                    tempRelay.isActive = Convert.ToBoolean(row["station_isActive"]);
                    tempRelay.isGateway = Convert.ToBoolean(row["isGateway"]);
                    if (tempRelay.id.Equals(PROCESSINGCENTERIP, StringComparison.Ordinal))
                    {
                        tempRelay.group = PROCESSINGCENTERGROUP;
                    }
                    else
                    {
                        tempRelay.group = RELAYGROUP;
                    }
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

            return numRelays-1;
        }

        public static void addRelay(string ipAddress, string ipConnectedTo, bool isGateway, string region, int queueLimit)
        {
            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (cn)
            {
                int gatewayBit;
                if (isGateway)
                    gatewayBit = 1;
                else
                    gatewayBit = 0;

                string _sql = @"INSERT INTO RelayStation (station_id, station_isActive, isGateway, region, queueLimit) VALUES('" + ipAddress + "', '" + 1 + "', '" + gatewayBit + "', '" 
                    + region +"', '" + queueLimit + "')";
                var cmd = new SqlCommand(_sql, cn);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

            Connection.addConnection(ipAddress, ipConnectedTo);
        }

        public static void addRegion(string regionName, string gatewayIP, string relayIP, string storeIP, string storeName)
        {
            addRelay(gatewayIP, PROCESSINGCENTERIP, true, regionName, 10);
            addRelay(relayIP, gatewayIP, false, regionName, 10);
            Store.addStore(storeIP, relayIP, storeName);
        }

        public static string getRegion(string ipAddress)
        {
            string region = "";

            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (cn)
            {
                DataTable table = new DataTable();
                DataRowCollection rows;
                string _sql = @"SELECT region FROM RelayStation WHERE station_id = '" + ipAddress + "'";
                var cmd = new SqlCommand(_sql, cn);

                cn.Open();

                table.Load(cmd.ExecuteReader());
                rows = table.Rows;

                foreach (DataRow row in rows)
                {
                    region = Convert.ToString(row["region"]);
                }
            }

            return region;
        }
    }
}