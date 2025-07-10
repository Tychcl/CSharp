using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr32.Classes
{
    public class DBConnection
    {
        public static string Connection()
        {
            if (ChangeableConnectionString != "")
                return ChangeableConnectionString;
            else
                return ConnectionString;
        }
        public static string ChangeableConnectionString = "";
        private static readonly string ConnectionString = "server=student.permaviat.ru;Trusted_Connection=No;DataBase=base2_ISP_22_1_4;User=ISP_22_1_4;PWD=0FHSdqSJsEG1_";

        public static DataTable Connection(string SQL)
        {
            DataTable dataTable = new DataTable("Datatable");
            SqlConnection sqlConnection = new SqlConnection(Connection());
            sqlConnection.Open();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = SQL;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        
    }
}
