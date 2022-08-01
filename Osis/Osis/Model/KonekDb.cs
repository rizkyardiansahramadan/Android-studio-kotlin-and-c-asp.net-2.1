using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Osis.Model
{
    public class KonekDb
    {
        private static String username = "root";
        private static string password = "";
        private static string server = "localhost";
        private static string db = "osis";
        private MySqlConnection conn;
        private string cs = @"server=" + server + ";userid=" +
            username + ";password=" + password + ";database=" + db;
        public MySqlConnection openConnection()
        {
            if (conn != null) { return conn; }
            else
            {
                conn = new MySqlConnection(cs);
                return conn;
            }
        }//end mysqlconnection
        public bool checkConnection()
        {
            bool result = false;
            MySqlConnection connection = openConnection();
            try
            {
                connection.Open();
                result = true;
                connection.Close();
            }
            catch (MySqlException ex)
            {
                String e = ex.ToString();
                result = false;
            }
            return result;
        }// end
    }
}
