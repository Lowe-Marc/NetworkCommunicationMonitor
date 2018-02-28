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
        public string name;

        public static List<Store> getStores()
        {
            List<Store> stores = new List<Store>();

            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (cn)
            {
                DataTable questionTable = new DataTable();
                DataRowCollection rows;
                string _sql = @"SELECT store_id, store_name FROM Store";
                var cmd = new SqlCommand(_sql, cn);

                cn.Open();

                questionTable.Load(cmd.ExecuteReader());
                rows = questionTable.Rows;

                foreach (DataRow row in rows)
                {
                    Store tempStore = new Store();
                    tempStore.ipAddress = Convert.ToString(row["store_id"]);
                    tempStore.name = Convert.ToString(row["store_name"]);
                    stores.Add(tempStore);
                }
            }

            return stores;
        }

        // Static query to get the number of stores
        public static int getNumStores()
        {
            return 0;

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
    }
}