using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr26.Common
{
    public static class DBConnection
    {
        public static SqlConnection OpenConnection()
        {
            SqlConnection sqlConnection = new SqlConnection("Server=DESKTOP-1B810QK\\DEV;DataBase=pr26; Trusted_Connection=True");
            sqlConnection.Open();
            return sqlConnection;
        }
        public static SqlDataReader Query(string query, SqlConnection sqlConnection)
        {
            return new SqlCommand(query, sqlConnection).ExecuteReader();
        }
        public static void CloseConnection(SqlConnection sqlConnection)
        {
            sqlConnection.Close();
        }
    }
}
