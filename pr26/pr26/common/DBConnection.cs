using System;
using System.Collections.Generic;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr26.Common
{
    public static class DBConnection
    {
        public static MySqlConnection OpenConnection()
        {
            try
            {
                MySqlConnection sqlConnection = new MySqlConnection("server=127.0.0.1;port=3306;database=pr26;uid=root;pwd=;");
                sqlConnection.Open();
                return sqlConnection;
            }
            catch
            {
                return null;
            }
        }
        public static MySqlDataReader Query(string query, MySqlConnection sqlConnection)
        {
            return new MySqlCommand(query, sqlConnection).ExecuteReader();
        }
        public static void CloseConnection(MySqlConnection sqlConnection)
        {
            sqlConnection.Close();
        }
    }
}
