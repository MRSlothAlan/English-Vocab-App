using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace EngVocabApp
{
    class SQLInstance
    {
        private string connectionString;
        private SqlConnection db;

        public SQLInstance(string in_conn_str) {
            this.connectionString = in_conn_str;
            if (this.db == null || this.db.State == System.Data.ConnectionState.Closed)
            {
                this.db = new SqlConnection();
                db.ConnectionString = connectionString;
                db.Open();
            }
        }

        public string getDBState()
        {
            return this.db.State.ToString();
        }

        public void ExecuteSQLNonQuery(string in_query)
        {
            SqlCommand command = new SqlCommand(in_query, this.db);
            command.ExecuteNonQuery();
        }

        public DataTable ExecuteSQLQuery(string in_query)
        {
            SqlDataAdapter adpt = new SqlDataAdapter(in_query, this.db);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            return dt;
        }

        public void CloseInstance()
        {
            db.Close();
        }
    }

    class SQLcontrol
    {
        /*
         * Get the same SQLInstance via control.
         * */
        private static SQLInstance curDBControl = null;
        private static string connStr;

        public static SQLInstance getInstance()
        {
            if (curDBControl == null)
            {
                curDBControl = new SQLInstance(connStr);
            }
            return curDBControl;
        }

        public static SQLInstance createInstance(string in_conn_str)
        {
            connStr = in_conn_str;
            if (curDBControl == null)
            {
                curDBControl = new SQLInstance(in_conn_str);
            }
            return curDBControl;
        }

        public static void resetInstance()
        {
            curDBControl.CloseInstance();
            curDBControl = new SQLInstance(connStr);
        }
    }
}
