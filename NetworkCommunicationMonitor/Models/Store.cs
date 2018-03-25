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
    public class Store
    {

        public string ipAddress;
        public string id;
        public string name;
        public string region;
        public int group;

        public static readonly int STOREGROUP = 1;

        public static List<Store> getStores()
        {
            List<Store> stores = new List<Store>();

            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (cn)
            {
                DataTable questionTable = new DataTable();
                DataRowCollection rows;
                string _sql = @"SELECT store_id, store_name, region FROM Store";
                var cmd = new SqlCommand(_sql, cn);

                cn.Open();

                questionTable.Load(cmd.ExecuteReader());
                rows = questionTable.Rows;

                foreach (DataRow row in rows)
                {
                    Store tempStore = new Store();
                    tempStore.ipAddress = Convert.ToString(row["store_id"]);
                    tempStore.id = Convert.ToString(row["store_id"]);
                    tempStore.name = Convert.ToString(row["store_name"]);
                    tempStore.region = Convert.ToString(row["region"]);
                    tempStore.group = STOREGROUP;
                    stores.Add(tempStore);
                }
                
            }

            return stores;
        }

        public static List<Object> getStoresForMap()
        {
            List<Object> stores = new List<Object>();

            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (cn)
            {
                DataTable questionTable = new DataTable();
                DataRowCollection rows;
                string _sql = @"SELECT store_id, store_name, region FROM Store";
                var cmd = new SqlCommand(_sql, cn);

                cn.Open();

                questionTable.Load(cmd.ExecuteReader());
                rows = questionTable.Rows;

                foreach (DataRow row in rows)
                {
                    Store tempStore = new Store();
                    tempStore.ipAddress = Convert.ToString(row["store_id"]);
                    tempStore.id = Convert.ToString(row["store_id"]);
                    tempStore.name = Convert.ToString(row["store_name"]);
                    tempStore.region = Convert.ToString(row["region"]);
                    tempStore.group = STOREGROUP;
                    stores.Add(tempStore);
                }
            }

            return stores;
        }

        // Static query to get the number of stores
        public static int getNumStores()
        {
            int numStores = 0;

            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (cn)
            {
                DataTable questionTable = new DataTable();
                DataRowCollection rows;
                string _sql = @"SELECT Count(*) FROM Store";
                var cmd = new SqlCommand(_sql, cn);

                cn.Open();

                questionTable.Load(cmd.ExecuteReader());
                rows = questionTable.Rows;

                foreach (DataRow row in rows)
                {
                    numStores = Convert.ToInt32(row[0]);
                }
            }

            return numStores;
        }

        public static void addStore(string ipAddress, string relayIP, string storeName)
        {
            string region = Relay.getRegion(relayIP);

            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (cn)
            {
                string _sql = @"INSERT INTO Store (store_id, store_name, region) VALUES(@IPAddress, @StoreName, @Region)";
                var cmd = new SqlCommand(_sql, cn);
                cmd.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = ipAddress;
                cmd.Parameters.Add("@StoreName", SqlDbType.VarChar).Value = storeName;
                cmd.Parameters.Add("@Region", SqlDbType.VarChar).Value = region;

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

            Connection.addConnection(ipAddress, relayIP);
        }
    }
}